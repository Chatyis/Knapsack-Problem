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
            Tuple<TextBox, DataGridView> viewControls;
            Item buforItem;
            Selection selection = SteadyStateSelection;
            Mixing mixing = MixingParentsKeeping;
            //Individual buforInd = new Individual();
            int selectionsAmount = int.Parse(amountOfSelectionsNumeric.Text), startingPopulation = int.Parse(populationNumeric.Text);
            float mutationOfAttribute = float.Parse(mutationOfAttributeNumeric.Text), mutationOfPopulation = float.Parse(mutationOfPopulationNumeric.Text), maximumWeight = float.Parse(maximumWeightNumeric.Text), minItemWeight = float.MaxValue, buforWeight = 0f;
            double minValue = double.MaxValue, maxValue = double.MinValue, sumBuf = 0, average=0, median=0,UQ=0,LQ=0, indValue;
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
                //resultsTextBox.Text = "Incorrect data!\n";
                MessageBox.Show("Incorrect data!");
                return;
            }
            if (!isBackpackPossible(ref items, maximumWeight))
            {
                MessageBox.Show("Capacity should be lower than weight of all items!");
                return;
            }
            viewControls = AddNewSelectionTab(selectionNumber++);
            selectionProgressBar.Maximum = selectionsAmount;
            // Setting new populations
            for (int j = 0; j < startingPopulation; j++) population.Add(GenerateIndividual(items, minItemWeight, random, maximumWeight));
            // Generating next selections
            if (selectionSteadyStateRadio.Checked)
            { 
                selection = SteadyStateSelection;
                viewControls.Item1.Text += "Selection: Steady State Selection\r\n";
            }
            else
            {
                selection = TournamentSelection;
                viewControls.Item1.Text += "Selection: Tournament Selection\r\n";
            }
            if (crossingMixingParentsRadio.Checked)
            {
                mixing = MixingParentsDestroying;
                viewControls.Item1.Text += "Mixing Method: Mixing with destroying parents\r\n";
            }
            else
            {
                mixing = MixingParentsKeeping;
                viewControls.Item1.Text += "Mixing Method: Mixing with keeping parents\r\n";
            }
            for (int i = 0; i < selectionsAmount; i++)
            {
                viewControls.Item1.Text += "Generation: " + i + "\r\n";
                selectionProgressBar.Value = i+1;
                selection(startingPopulation, ref population, minItemWeight, random, maximumWeight, mixing);
                // Mutating
                MutatePopulation(ref population, mutationOfPopulation, mutationOfAttribute, maximumWeight, ref items, minItemWeight);
                z = 0;
                sumBuf = 0;
                message = "";
                foreach (Individual ind in population)
                {
                    indValue = ind.getValue();
                    message += "Individual: " + z++ + " " + indValue + " " + ind.getWeight();
                    foreach(Item item in ind.getItems())
                    {
                        message += " " + item.getName();
                    }
                    message += "\r\n";
                    sumBuf += indValue;
                    if (minValue > indValue) minValue = indValue;
                    if (maxValue < indValue) maxValue = indValue;
                }
                // For standard deviation
                average = sumBuf / startingPopulation;
                sumBuf = 0;
                foreach (Individual ind in population)
                {
                    sumBuf = (average - ind.getValue()) * (average - ind.getValue());
                }
                //Sort before finding median, UQ, BQ
                population = population.OrderBy(o => o.getValue()).ToList();
                if (startingPopulation % 2 == 0) //E
                {
                    median = (population[(startingPopulation / 2) - 1].getValue() + population[startingPopulation / 2].getValue())/2;
                    if ((startingPopulation/2) % 2 == 0)//E
                    {
                        LQ = (population[(startingPopulation / 4) - 1].getValue() + population[startingPopulation / 4].getValue())/2;
                        UQ = (population[(startingPopulation / 4) + (startingPopulation / 2) - 1].getValue() + population[startingPopulation / 4 + (startingPopulation / 2)].getValue())/2;
                    }
                    else //O
                    {
                        LQ = population[startingPopulation / 4].getValue();
                        UQ = population[(startingPopulation / 4) + (startingPopulation / 2)].getValue();
                    }
                }
                else //O
                {
                    median = population[startingPopulation / 2].getValue();
                    if ((startingPopulation / 2) % 2 == 0)//E
                    {
                        LQ = (population[(startingPopulation / 4) - 1].getValue() + population[startingPopulation / 4].getValue()) / 2;
                        UQ = (population[(startingPopulation / 4) + (startingPopulation / 2) + 1].getValue() + population[startingPopulation / 4 + (startingPopulation / 2)].getValue()) / 2;
                    }
                    else //O
                    {
                        LQ = population[startingPopulation / 4].getValue();
                        UQ = population[(startingPopulation / 4) + (startingPopulation / 2) + 1].getValue();
                    }
                }
                viewControls.Item1.Text += message;
                viewControls.Item2.Rows.Add(new Object[] { i, average, maxValue, Math.Sqrt(sumBuf/(startingPopulation-1)), LQ, median, UQ });
            }
            selectionProgressBar.Value = 0;
        }
        private Tuple<TextBox, DataGridView> AddNewSelectionTab(int selectionNumber)
        {
            TabPage tp = new TabPage("Selection " + selectionNumber);
            tabControl1.TabPages.Add(tp);

            TextBox tbView1 = new TextBox();
            tbView1.Dock = DockStyle.Fill;
            tbView1.Multiline = true;
            tbView1.WordWrap = false;
            tbView1.ScrollBars = ScrollBars.Both;
            tbView1.ReadOnly = true;
            if (!isSelectionDisplayed) tbView1.Hide();
            tp.Controls.Add(tbView1);

            //TextBox tbView2 = new TextBox();
            //tbView2.Dock = DockStyle.Fill;
            //tbView2.Multiline = true;
            //tbView2.ScrollBars = ScrollBars.Vertical;
            //tbView2.ReadOnly = true;
            //tbView2.TextAlign = HorizontalAlignment.Center;
            //if (isSelectionDisplayed)tbView2.Hide();
            //tp.Controls.Add(tbView2);

            DataGridView dg = new DataGridView();
            dg.DefaultCellStyle.Font = new Font("Arial", 10f, GraphicsUnit.Pixel);
            dg.Dock = DockStyle.Fill;
            dg.ColumnCount = 7;
            dg.RowHeadersVisible = false;
            dg.Columns[0].Name = "Gen";
            dg.Columns[1].Name = "Average";
            dg.Columns[2].Name = "Maximum";
            dg.Columns[3].Name = "SD";
            dg.Columns[4].Name = "LQ";
            dg.Columns[5].Name = "Median";
            dg.Columns[6].Name = "UQ";
            dg.Columns[0].Width = 32;
            for (int i=1;i<7;i++)
                dg.Columns[i].Width = 68;
            dg.ReadOnly = true;
            if (isSelectionDisplayed) dg.Hide();
            tp.Controls.Add(dg);

            tabControl1.SelectedTab = tp;
            Tuple<TextBox, DataGridView> tb = Tuple.Create(tbView1, dg);
            return tb;
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
            int a = 0;
            foreach (Individual indiv in population)
            {
                if (random.Next(99) < mutationOfPopulation)
                {
                    // Delete % of items
                    for (int i = 0; i < Math.Ceiling((mutationOfAttribute / 100 ) * indiv.getItems().Count); i++) indiv.removeItem(random.Next(indiv.getItems().Count));
                    // At this moment algorithm needs to randomize items that will fit in removed once, and wouldn't add item if the randomised item is the same
                    for (int i = 0; i < (mutationOfAttribute / 100) * indiv.getItems().Count; i++) 
                    {
                        a = 0;
                        if (maximumWeight - indiv.getWeight() > minItemWeight)
                        {
                            do
                            {
                                buforItem = listOfItems[random.Next(listOfItems.Count)];
                                a++;
                            } while ((indiv.getWeight() + buforItem.getWeight() > maximumWeight || indiv.getItems().Contains(buforItem))&&a<=100);
                            if (a <= 100) indiv.addItem(buforItem);
                        }
                    }
                }
            }
        }
        private bool isBackpackPossible(ref List<Item> items, double capacity)
        {
            double weight=0;
            foreach(Item item in items) weight += item.getWeight();
            if (weight > capacity) return true;
            else return false;
        }
    }
}
