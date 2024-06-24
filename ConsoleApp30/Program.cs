using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp30.Program.SubsystemC;

namespace ConsoleApp30
{
    internal class Program
    {

        public class SubsystemA
        {
            public void A1()
            {

            }

            public void SubsystemA0()
            {

            }
        }


        public class SubsystemB
        {
            public void B1()
            {

            }

            public void SubsystemB0()
            {

            }
        }

        public class SubsystemC
        {
            public void C1()
            {

            }

            public void SubsystemC0()
            {

            }


            public class Facade
            {
                private SubsystemA _subsystemA;
                private SubsystemB _subsystemB;
                private SubsystemC _subsystemC;

                public Facade()
                {
                    _subsystemA = new SubsystemA();
                    _subsystemB = new SubsystemB();
                    _subsystemC = new SubsystemC();
                }

                public void Operation1()
                {

                    _subsystemA.A1();
                    _subsystemB.B1();
                    _subsystemC.C1();
                }

                public void Operation2()
                {

                    _subsystemA.SubsystemA0();
                    _subsystemB.SubsystemB0();
                    _subsystemC.SubsystemC0();
                }
            }

            //Адаптер


            public class Target
            {
                public virtual void Request()
                {
                    Console.WriteLine("Target: Default behavior.");
                }
            }

            
            public class Adaptee
            {
                public void SpecificRequest()
                {
                    Console.WriteLine("Adaptee: Specific behavior.");
                }
            }

           
            public class Adapter : Target
            {
                private readonly Adaptee _adaptee;

                public Adapter(Adaptee adaptee)
                {
                    _adaptee = adaptee;
                }

                public override void Request()
                {
                    
                    _adaptee.SpecificRequest();
                }
            }


            public class Client
            {
                public void Request(Target target)
                {
                    target.Request();
                }
            }
            static void Main(string[] args)
            {
                Facade facade = new Facade();
                facade.Operation1();
                facade.Operation2();

               

                //Aдаптер

                Client client = new Client();


                Target target = new Target();
                client.Request(target);

                
                Adaptee adaptee = new Adaptee();
                Target adapter = new Adapter(adaptee);
                client.Request(adapter);


                Console.ReadKey();

            }
        }
    }
}

