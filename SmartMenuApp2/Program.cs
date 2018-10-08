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
            Bindings binds = new Bindings();             SmartMenu menu = new SmartMenu(binds);              binds.Bind("this", This);             binds.Bind("that", That);             binds.Bind("something", Something);             binds.Bind("another", Another);             binds.Bind("lang", changeLang);              menu.LoadMenu("MenuSpec.txt");             menu.Activate();              void changeLang() {
                Console.Write("Danish or English? (EN for English and DA for Danish): ");
                string answer = Console.ReadLine();
                if (answer.ToLower().Trim() == "en") {
                    menu.LoadMenu("MenuSpec.txt");
                } else if (answer.ToLower().Trim() == "da") {
                    menu.LoadMenu("DAMenuSpec.txt");
                }

            }         }          private void This() {             Console.WriteLine(Functions.DoThis());         }          private void That() {             Console.WriteLine(Functions.DoThat());         }          private void Something() {             Console.WriteLine("What do you want to do?");             Console.WriteLine(Functions.DoSomething(Console.ReadLine()));         }          private void Another() {
            Console.WriteLine(Functions.GetTheAnswerToLifeTheUniverseAndEverything());

        }
    }
    }
