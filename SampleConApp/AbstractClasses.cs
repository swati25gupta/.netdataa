using System;
/* The class should be declared abstract
 * One of the methods of the abstract class must be declared as abstract and will not have a body. Methods with no implementation are abstract methods. 
 * The derived class must implement all the abstract methods, else even the derived must be declared as abstract. 
 * Its good practise to create an object of the Abstract class and instantiate it to the derived class that implements it.
 * abstract classes can still have normal and virtual methods in them.
 */
namespace SampleConApp
{
    abstract class Account
    {
        public int AccountNo { get; set; }
        public string Name { get; set; }
        public double Balance { get; protected set; }

        public void CreditAmount(double amount)
        {
            this.Balance += amount;
        }

        public void Debit(double amount)
        {
            if (amount > Balance)
            {
                Balance -= 100;//Penalty.....
                throw new Exception("Insufficient Funds");
            }
            Balance -= amount;
        }

        public abstract void CalculateInterest();
    }
    //override is also used on abstract methods....
    class SBAccount : Account
    {
        public override void CalculateInterest()
        {
            double interest = Balance * 8 / 100 * 0.5;//Half yearly calculation...
            Balance += interest;//Balance is accessible in its derived classes....
        }
    }
    class AbstractClassesDemo
    {
        static void Main(string[] args)
        {
            Account acc = new SBAccount();//The class is incomplete, so U cannot instantiate it....
            acc.AccountNo = 12323;
            acc.Name = "Phaniraj";
            acc.CreditAmount(5000);
            try
            {
                acc.Debit(6500);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //acc.CalculateInterest();
            Console.WriteLine("The current balance is " + acc.Balance);
        }
    }
}