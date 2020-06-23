using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessRule
{
    public class Product : IProduct
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        protected void GenerateCommision()
        {
            Logger.Log("Generate a commission payment to the agent.");
        }

        public virtual void ExecuteOrder()
        {
            Logger.Log("Generate a packing slip for shipping.");

            this.GenerateCommision();
        }
    }
    public class Book : Product
    {
        public override void ExecuteOrder()
        {
            Logger.Log("Create a duplicate packing slip for the royalty department.");

            base.GenerateCommision();
        }
    }

    public abstract class Physical : IProduct
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public virtual void ExecuteOrder()
        {
            Logger.Log("Execute default delivery");

        }

    }

    public class Video : Physical
    {
        public override void ExecuteOrder()
        {
            if (this.Name.Equals("Learning to Ski,"))
            {
                Logger.Log("First Aid");

            }

        }
    }

    public class Membership : Physical
    {
        private bool isActive = true;

        public Membership(bool isActive)
        {
            this.isActive = isActive;
        }

        public override void ExecuteOrder()
        {
            if (isActive)
            {
                ActivateMemebership();
            }
            else
            {
                UpdgradeMemebership();
            }

            Logger.Log("E-mail sent and informed the owner of the activation/upgrade.");

        }

        private void ActivateMemebership()
        {
            Logger.Log("Activate Membership.");

        }

        private void UpdgradeMemebership()
        {
            Logger.Log("Apply to upgrade.");

        }
    }
}
