//Static methods(behave like global functions), Instance methods(Relative to the object of the class), Anonymous methods(Delegates and Lambda Expressions)...
//If UR class has only static members, then U could mark that class as static.  It stops the user from creating the object as there is no need for it. Console class is one such static class where the programmer is not allowed to create the instance of the Console class as all the methods and the properties are static and are invoked by its classname....
using System;
class Data
{
    public static int commondata;//static is a way of creating variables which are behaving like global, thereby making the objects share the data. There will be a single reference of the variable across the program. It will be created once when U make a reference of it in ur program and will remain so till the program terminates. 
    public int data1;
    public void setValue(int no)
    {
        commondata = no;
    }

    public void displayValue()
    {
        Console.WriteLine("The value:" + commondata);
    }
}

class MethodsProgram
{
    //The ref makes the parameter to be passed as reference and no copy of the variable would be passed. So any changes made by the function will be reflected on the actual variable itself...
    static void addFunc(int v1, int v2, ref int res)
    {
        //parameters are local to the function that is using it...
        res = v1 + v2;
    }

    //Pass by out parameter is another way of passing reference variables into a method. Only difference is the variable is initialized before passing to a method in pass by ref, but in Pass by Out, the variable is uninitialized, and value will be an actual output of the method, hense the name out, The value will be a out parameter. 
    static void mathOperation(double v1, double v2, ref double added, ref double subtracted, out double multiplied, out double divided)
    {
        added = v1 + v2;
        subtracted = v1 - v2;
        multiplied = v1 * v2;
        if (v2 != 0)
            divided = v1 / v2;
        else
            divided = 0;
    }
    //params are variable no args to be passed....
    static int getAddedValue(params int[] args)
    {
        //params is the way to pass different no of arguments of the same type into a function. similar to ... of Java and C++...
        //there should be only one params for a given functions. 
        //params should the last of the parameter list. 
        //params must always be passed by value. 
        int res = 0;
        foreach (int v in args)
            res += v;
        return res;
    }
    static void Main(string[] args)
    {
        int res = getAddedValue(123, 234, 345, 345, 345, 234, 234, 234, 534, 534, 534, 5345);
        Console.WriteLine("The added: " + res);

        double v1 = 123, v2 = 23, added =0, subtracted = 0;
        double mulValue, divValue;
        mathOperation(v1, v2, ref added, ref subtracted, out mulValue, out divValue);
        Console.WriteLine("The output is:\nThe added value:{0}\nThe Subtrated value:{1}\nThe multiplied value:{2}\nThe divided value:{3}", added, subtracted, mulValue, divValue);
        //addFunc(v1, v2, ref res);
        //Console.WriteLine("The Result is " + res);

        //staticExample();
    }

    private static void staticExample()
    {
        Data.commondata = 543;
        Data d1 = new Data { data1 = 123 };
        d1.setValue(23455);
        Data d2 = new Data { data1 = 234 };//Object initialization syntax in C#....
        Console.WriteLine("Value of data:" + d1.data1);
        Console.WriteLine("Value of data:" + d2.data1);
    }
}
