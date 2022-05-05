using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProblemPlecakowy
{
    public partial class Form1 : Form
    {
        private void GeneticAlgorithm()
        {
            //MessageBox.Show("My message here");
            // Posortowac osobniki wedlug wartosci potem uciac tablice na pol.
            // Tournament Selection - make new list containing 50% of the best, and second list containing those who lost
            // Jezeli max waga - waga przedmiotow < min waga przedmiotow (waga najlzejszego) -> generuj nastepny plecak 
            // Maximum weight can't be lower than total weight of items 
            List<Item> items = new List<Item>();
            List<Individual> population = new List<Individual>();
            Item buforItem;
            Selection selection = SteadyStateSelection;
            Mixing mixing = MixingParentsKeeping;

            //Individual buforInd = new Individual();
            int selectionsAmount = int.Parse(amountOfSelectionsTextBox.Text), startingPopulation = int.Parse(populationTextBox.Text);
            float mutationOfAttribute = float.Parse(mutationOfAttributeTextBox.Text), mutationOfPopulation = float.Parse(mutationOfPopulationTextBox.Text), maximumWeight = float.Parse(maximumWeightTextBox.Text), minItemWeight = float.MaxValue, buforWeight = 0f;
            //string[] inputS = System.IO.File.ReadAllLines("../../data.txt");
            string[] inputS = System.IO.File.ReadAllLines(uploadFileOFD.FileName);
            var random = new Random();
            int z = 0;
            string message = "";

            // Loading items, finding minimal weight
            try
            { 
                foreach (string line in inputS)
                {
                    buforWeight = float.Parse(line.Split(' ')[2]);
                    items.Add(new Item(line.Split(' ')[0], float.Parse(line.Split(' ')[1]), buforWeight));
                    if (buforWeight < minItemWeight) minItemWeight = buforWeight;
                }
            }
            catch
            {
                resultsTextBox.Text = "Incorrect data!\n";
                return;
            }
            selectionProgressBar.Maximum = selectionsAmount;
            // Setting new populations
            for (int j = 0; j < startingPopulation; j++) population.Add(GenerateIndividual(items, minItemWeight, random, maximumWeight));
            // Generating next selections
            if (selectionSteadyStateRadio.Checked)
            { 
                selection = SteadyStateSelection;
                resultsTextBox.Text += "Selection: Steady State Selection\n";
            }
            else
            {
                selection = TournamentSelection;
                resultsTextBox.Text += "Selection: Tournament Selection\n";
            }
            if (crossingMixingParentsRadio.Checked)
            {
                mixing = MixingParentsDestroying;
                resultsTextBox.Text += "Mixing Method: Mixing with destroying parents\n";
            }
            else
            {
                mixing = MixingParentsKeeping;
                resultsTextBox.Text += "Mixing Method: Mixing with keeping parents\n";
            }
            for (int i = 0; i < selectionsAmount; i++)
            {
                resultsTextBox.Text += "Selection: "+i+"\n";
                selectionProgressBar.Value = i+1;
                // Selection
                //SteadyStateSelection(startingPopulation, ref population, minItemWeight, random, maximumWeight, MixingParentsAttributes);
                //selection(startingPopulation, ref population, minItemWeight, random, maximumWeight, MixingParentsDestroying);
                selection(startingPopulation, ref population, minItemWeight, random, maximumWeight, mixing);
                // Mutating
                MutatePopulation(ref population, mutationOfPopulation, mutationOfAttribute, maximumWeight, ref items, minItemWeight);
                z = 0;
                message = "";
                foreach (Individual ind in population)
                {
                    message += "Individual: " + z++ + " " + ind.getValue() + " " + ind.getWeight() + "\n";
                }
                resultsTextBox.Text += message;
            }
            selectionProgressBar.Value = 0;
        }
        private delegate void Selection(int startingPopulation, ref List<Individual> population, float minItemWeight, Random random, float maximumWeight, Mixing mixingMethod);
        private delegate List<Individual> Mixing(int startingPopulation, List<Individual> population, Random random, float maximumWeight);
        private Individual GenerateIndividual(List<Item> listOfItems, float minItemWeight, Random random, float maximumWeight)
        {
            Individual indiv = new Individual();
            Item buforItem = new Item();
            int a = 0; // !!! Code could need a better fixing that this (also for optimization)
            do
            {
                a = 0;
                do
                {
                    buforItem = listOfItems[random.Next(listOfItems.Count)];
                    a++;
                } while ((indiv.getWeight() + buforItem.getWeight() > maximumWeight || indiv.getItems().Contains(buforItem))&& a<=100); //Checking if item fit and isn't already in backpack
                if(a<=100) indiv.addItem(buforItem);
            } while (maximumWeight - indiv.getWeight() > minItemWeight && a <= 100); // Checking if there are any items that can be added to backpack
            return indiv;
        }
        private List<Individual> MixingParentsKeeping(int startingPopulation, List<Individual> population, Random random, float maximumWeight)
        {
            for (int j = 0; j < Math.Floor(startingPopulation /2f); j += 2)
            {
                // set of items from both parents
                List<Item> itemsBuf = new List<Item>();
                itemsBuf.AddRange(population[j].getItems());
                itemsBuf.AddRange(population[j + 1].getItems());
                float minItemWeight = float.MaxValue;
                foreach (Item item in itemsBuf) { if (minItemWeight > item.getWeight()) minItemWeight = item.getWeight(); }
                for (int x = 0; x < 2; x++)
                {
                    population.Add(GenerateIndividual(itemsBuf, minItemWeight, random, maximumWeight));
                }
            }
            return population;
        }
        private List<Individual> MixingParentsDestroying(int startingPopulation, List<Individual> population, Random random, float maximumWeight)
        {
            for (int j = 0; j < Math.Floor(startingPopulation / 2f); j += 2)
            {
                // set of items from both parents
                List<Item> itemsBuf = new List<Item>();
                itemsBuf.AddRange(population[j].getItems());
                itemsBuf.AddRange(population[j + 1].getItems());
                float minItemWeight = float.MaxValue;
                foreach (Item item in itemsBuf) { if (minItemWeight > item.getWeight()) minItemWeight = item.getWeight(); }
                for (int x = 0; x < 4; x++)
                {
                    population.Add(GenerateIndividual(itemsBuf, minItemWeight, random, maximumWeight));
                }
            }
            // At the end remove parents that are at the beginning because childs are made by destroying them (the other half, that is weak is removed by selection part of code)
            population.RemoveRange(0, (int)Math.Round((startingPopulation + 1) / 2f));
            return population;
        }
        private void SteadyStateSelection(int startingPopulation, ref List<Individual> population, float minItemWeight, Random random, float maximumWeight,  Mixing mixingMethod)
        {
            population = population.OrderByDescending(o => o.getValue()).ToList();
            population = mixingMethod(startingPopulation, population, random, maximumWeight);
            population = population.OrderBy(o => o.getValue()).ToList();
            population.RemoveRange(0, (int)Math.Round((startingPopulation+1) / 2f));
        }
        private void TournamentSelection(int startingPopulation, ref List<Individual> population, float minItemWeight, Random random, float maximumWeight, Mixing mixingMethod)
        {
            int n = 5;
            List<Individual> wonIndividuals = new List<Individual>();
            List<Individual> lostIndividuals = new List<Individual>();
            List<Individual> bufIndividuals = new List<Individual>();
            // first ceil then floor and swap between those two each group.
            for (int i = 0; i < (population.Count/n)*n; i += n)
            {
                bufIndividuals = population.GetRange(i, n).OrderBy(o => o.getValue()).ToList();
                wonIndividuals.AddRange(bufIndividuals.GetRange(0, (n/2)+(i+n)%2));
                lostIndividuals.AddRange(bufIndividuals.GetRange( (n / 2) + (i + n) % 2, n - ((n / 2) + (i + n) % 2)));
            }
            int populationLeft = population.Count - (population.Count / n) * n;
            if (populationLeft > 0) 
            { 
                bufIndividuals = population.GetRange((population.Count / n) * n, populationLeft).OrderBy(o => o.getValue()).ToList();
                wonIndividuals.AddRange(bufIndividuals.GetRange(0, populationLeft / 2));
                lostIndividuals.AddRange(bufIndividuals.GetRange(populationLeft / 2, (int)Math.Round(populationLeft/2f)));
            }
            population = wonIndividuals;
            population.AddRange(lostIndividuals);

            population = mixingMethod(startingPopulation, population, random, maximumWeight);
            population = population.OrderBy(o => o.getValue()).ToList();
            population.RemoveRange(0, (int)Math.Round((startingPopulation + 1) / 2f));
        }
        private void MutatePopulation(ref List<Individual> population, float mutationOfPopulation, float mutationOfAttribute, float maximumWeight, ref List<Item> listOfItems, float minItemWeight)
        {
            var random = new Random();
            Item buforItem = new Item();
            foreach (Individual indiv in population)
            {
                if (random.Next(99) < mutationOfPopulation)
                {
                    // Delete % of items
                    for (int i = 0; i < (mutationOfAttribute / 100 ) * indiv.getItems().Count; i++) indiv.removeItem(random.Next(indiv.getItems().Count));
                    // At this moment algorithm needs to randomize items that will fit in removed once, and wouldn't add item if the randomised item
                    for (int i = 0; i < (mutationOfAttribute / 100) * indiv.getItems().Count; i++) 
                    {
                        if (maximumWeight - indiv.getWeight() > minItemWeight)
                        {
                            do
                            {
                                buforItem = listOfItems[random.Next(listOfItems.Count)];
                            } while (indiv.getWeight() + buforItem.getWeight() > maximumWeight || indiv.getItems().Contains(buforItem));
                            indiv.addItem(buforItem);
                        }
                    }
                }
            }
        }
    }
}
