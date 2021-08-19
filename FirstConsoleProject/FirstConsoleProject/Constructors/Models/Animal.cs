using System;

namespace Constructors.Models
{
    public class Animal
    {
        private int _quantityLegs;
       private int _quantityTail;
        public int QuantityLegs
        { 
            get=>_quantityLegs; 
            set 
            {
                if (value<0)
                {
                    throw new Exception("Legs cant be less 0");
                }
                _quantityLegs = value; 
            } 
        }
        public int QuantityTail
        {
            get => _quantityTail;
            set
            {
                _quantityTail = value;
            }
        }
        public Animal()
        {

        }
        public Animal(int quantityLegs,int quantityTail)
        {
            QuantityLegs = quantityLegs;
            QuantityTail = quantityTail;
        }
    }
}
