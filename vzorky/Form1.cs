using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Globalization;

namespace vzorky {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        string path_to_directory;

        private void chooseExcelFile_Click(object sender, EventArgs e) {

            try {

                OpenFileDialog ofd = new OpenFileDialog();
                ofd.ShowDialog();
                string nameOfExcelFile = ofd.FileName;

                System.IO.StreamReader file = new System.IO.StreamReader(nameOfExcelFile, System.Text.Encoding.UTF8);
                string j;

                int well = -1;
                int sample = -1;
                int primer = -1;
                int pcr = -1;
                int name = -1;
                string date = "X";

                while ((j = file.ReadLine()) != null) {
                    j = j.Replace("\"", ""); j = j.Replace("\'", "");
                    string test = j.ToLower();

                    if (test.Contains("sekvenace")) {
                        date = Regex.Match(test, @"\d+").Value;
                        Console.WriteLine("date: " + date);
                    } else {

                        if (test.Contains("well")) {
                            char[] separators = { ',', ';', ':', '\t' };
                            string[] parts = test.Split(separators);

                            for (int i = 0; i < parts.Count(); i++) {
                                if (parts[i].Contains("well")) {
                                    well = i;
                                } else {
                                    if (parts[i].Contains("sample")) {
                                        sample = i;
                                    } else {
                                        if (parts[i].Contains("primer")) {
                                            primer = i;
                                        } else {
                                            if (parts[i].Contains("pcr")) {
                                                pcr = i;
                                            } else {
                                                if (parts[i].Contains("name")) {
                                                    name = i;
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                        } else {

                            if (!(string.IsNullOrWhiteSpace(test))) {

                                Console.WriteLine(j);

                                char[] separators = { ',', ';', ':', '\t' };
                                string[] parts = j.Split(separators);
                                if (parts.Count() >= 6) {
                                    Console.WriteLine("well: " + well + "sample: " + sample + "primer: " + primer + "pcr: " + pcr + "name: " + name);
                                    Console.WriteLine("well: " + parts[well] + "sample: " + parts[sample] + "primer: " + parts[primer] + "pcr: " + parts[pcr] + "name:" + parts[name]);

                                    string lowerCase = parts[name].ToLower();
                                    string lowercaseNameWithoutDiacritics = RemoveDiacritics(lowerCase);
                                    string folder = Convert.ToString(path_to_directory + "\\" + lowercaseNameWithoutDiacritics + "_" + date);
                                    if (Directory.Exists(folder) == false) {
                                        Console.WriteLine("creating directory " + folder);
                                        System.IO.Directory.CreateDirectory(@folder);
                                    } else {
                                        //Console.WriteLine("directory " + folder + " already exists");
                                    }

                                    //moving files into directory
                                    string pattern = parts[well] + "\\.";
                                    Regex reg = new Regex(pattern);
                                    var files = Directory.GetFiles(path_to_directory, "*.*").Where(path => reg.IsMatch(path));

                                    foreach (var f in files) {
                                        Console.WriteLine(f);
                                        string fileEnding = f.Substring(f.IndexOf("."));
                                        string new_name;
                                        if (string.IsNullOrWhiteSpace(parts[primer])) {
                                            new_name = parts[sample];
                                        } else {
                                            new_name = parts[sample] + "_" + parts[primer];
                                        }

                                        new_name = path_to_directory + "\\" + lowercaseNameWithoutDiacritics + "_" + date + "\\" + new_name + fileEnding;
                                        Console.WriteLine("moving " + f + " to " + new_name);
                                        File.Move(f, new_name);
                                    }
                                    Console.WriteLine();


                                } else {
                                    MessageBox.Show("This line wont be used because of wrong format: " + Environment.NewLine + j);
                                }
                            }
                        }
                    }
                }
                MessageBox.Show("Hotovo.");
            } catch (Exception ex) {
                MessageBox.Show("Pravděpodobně špatný formát vstupu. Aplikace bude ukončena. " + Environment.NewLine + "Zpráva: " + ex.Message);
            }
            this.Close();
        }

        private void releaseObject(object obj) {
            try {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            } catch (Exception ex) {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            } finally {
                GC.Collect();
            }
        }

        static string RemoveDiacritics(string stIn) {
            string stFormD = stIn.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();

            for (int ich = 0; ich < stFormD.Length; ich++) {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
                if (uc != UnicodeCategory.NonSpacingMark) {
                    sb.Append(stFormD[ich]);
                }
            }

            return (sb.ToString().Normalize(NormalizationForm.FormC));
        }

        private void chooseSequenceDirectory_Click(object sender, EventArgs e) {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            path_to_directory = fbd.SelectedPath;
            MessageBox.Show("Vybráno.");
            chooseSequenceDirectory.Enabled = false;
            chooseExcelFile.Enabled = true;
        }



    }
}
