using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartMenuLibrary;
using FunctionLibrary;

namespace SmartMenuApp2 {
    class Program {
        static void Main(string[] args) {
            Program myProgram = new Program();
            myProgram.Run();
        }

        private void Run() {
            // Make bindings and bind options
            Bindings binds = new Bindings();
            SmartMenu menu = new SmartMenu(binds);
            menu.lang = "en";
            binds.Bind("this", This);
            binds.Bind("that", That);
            binds.Bind("something", Something);
            binds.Bind("another", Another);
            binds.Bind("lang", changeLang);

            menu.LoadMenu("MenuSpec.txt");
            menu.Activate();

            void changeLang() {
                if (menu.lang == "en") {
                    Console.Write("Danish or English? (EN for English and DA for Danish): ");
                } else {
                    Console.Write("Dansk eller Engelsk ? (EN for Engelsk and DA for Dansk): ");
                }
                
                string answer = Console.ReadLine();
                if (answer.ToLower().Trim() == "en") {
                    menu.LoadMenu("MenuSpec.txt");
                    menu.lang = "en";
                } else if (answer.ToLower().Trim() == "da") {
                    menu.LoadMenu("DAMenuSpec.txt");
                    menu.lang = "da";
                }

            }

            void Something() {
                if(menu.lang == "en") {
                    Console.WriteLine("What do you want to do?");
                } else {
                    Console.WriteLine("Hvad vil du gøre?");
                }
                
                Console.WriteLine(Functions.DoSomething(Console.ReadLine()));
            }
        }

        private void This() {
            Console.WriteLine(Functions.DoThis());
        }

        private void That() {
            Console.WriteLine(Functions.DoThat());
        }



        private void Another() {
            Console.WriteLine(Functions.GetTheAnswerToLifeTheUniverseAndEverything());

        }
    }
    }
