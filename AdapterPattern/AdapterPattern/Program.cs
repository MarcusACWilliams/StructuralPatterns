using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create client object with a reference to the adapter
            Client testClient = new Client(new AdapterClass());
            testClient.ServiceRequest();

            //Keep console open
            Console.ReadKey();
        }
    }

    //In this example we have a Client that needs to call the method "DoMoreSpecificStuff".
    //For whatever reason the Client Class is incopatiable with the methods class.
    //To fix this problem we create an interface with a method that the Client can use. This 
    //interface is then implemented by our adapter class. The Client then uses this object to
    //access the desired method
    
    class Client
    {
        //Instance of the interface
        private ITarget targetInterface;

        //Client Constructor that takes interface object
        public Client(ITarget target)
        {
            targetInterface = target;
        }

        //Have this method call our target method using reference
        public void ServiceRequest()
        {
            targetInterface.DoStuff();
        }

    }

    //Adaptee... 
    class IncompatibleClass
    {
        public void DoMoreSpecificStuff()
        {
            Console.WriteLine("This is the Correct Method!");
        }
    }

    //Target
    public interface ITarget
    {
         void DoStuff();     
    }


    /* NOTE
     * For this particular Implementation I decided to make the Adapter Class a child of
     * the Adaptee Class and also have it Implement the Target interface. I'm using multiple 
     * sources for this excersice and have seen this implemented bith ways.
     */

    /* SECOND NOTE
     * The implementation of ITarget is mandatory in the Adapter Class. Here the Interface acts
     * as a contract that ensures that any object passed into Client has implemented the correct 
     * interface. By passing the type ITarget into the Clients constructor, instead of the type 
     * AdapterClass, we are free to create different Adapters for this client if the need arises 
     * in the future.
     */

    /*THIRD NOTE
     * I think the only advantage to inheriting from the Adaptee in this case is ease of use. It 
     * isn't neccesary to create a new Adaptee object inorder to access the target method. As I'm
     * writing this, I realize that this inheritance implementation prevents us from using this
     * adapter on other possible memebers of this class family. For example if there was a 
     * BaseAdaptee class with children Adaptee and AdapteeToo, this particular Adapter could not
     * be used on the second class. I'm pretty sure that the name Adapter implies that we shoudn't 
     * be coupling it to another class so tightly. 
     */

    //Adapter
    class AdapterClass : IncompatibleClass, ITarget
    {
        public void DoStuff()
        {
            DoMoreSpecificStuff();
        }
    }




}
