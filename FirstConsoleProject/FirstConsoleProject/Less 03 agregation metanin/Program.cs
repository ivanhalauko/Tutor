using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less_03_agregation_metanin
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine(5);
            Car car = new Car(engine);
            int power = 300;
            Boat boat = new Boat(power);
            boat.Engine.ToString();
            Console.WriteLine(boat.Engine.PowEngine);
            ShattleEngine shattleEngine = new ShattleEngine();
            Car car1 = new Car(shattleEngine);
        }
    }
    public interface IEngine
    {
        int PowEngine { get; set; }
        void StopEngine(int power);
    }
    public class Engine:IEngine
    {
        private int _power;

        public Engine(int power)
        {
            _power = power;
        }
        public int PowEngine { get=>_power; set { _power = value; } }
        public void StopEngine(int power)
        {
            if (power>100)
            {
                Console.WriteLine("break engine");
            }
            else
            {
                Console.WriteLine("engine stopt");
            }
        }
    }
    public class ShattleEngine : IEngine
    {
        private int _powerengine;
        public int PowEngine { get =>1000; set { _powerengine = value; } }

        public void StopEngine(int power)
        {
            Console.WriteLine("Engine Stoped");
        }
    }
    public class Car
    {
        IEngine engine;
        public Car(IEngine eng)// Agragation
        {
            engine = eng;
        }
    }
    public class Boat
    {
        Engine engine;

        public Boat(int power)//Composition
        {
            this.engine = new Engine(power);
        }
        public Engine Engine 
        { 
            get=>engine;
            set
            {
                engine = value;
            } 
        }
    }
}
