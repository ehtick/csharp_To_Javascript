using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

public interface Type_0
{
    int Prop_0 { get; }

    abstract Type_4 Method_1(string p0, Type_4 p1, string p2);
}

public interface Type_1
{
    Type_4 Prop_1 { get; }

    Type_4 Prop_3 { get; set; }

    abstract bool Method_0(Type_2 p0, bool p1, Type_4 p2);
    abstract Type_4 Method_2(Type_4 p0);
}

public struct Type_2 : Type_4
{
    public Type_4 Prop_0 { get; set; }
}

public struct Type_3
{
    public static Type_2 Prop_0 { get; }
    public string Prop_1 { get; set; }
}

public interface Type_4
{
    string Prop_0 { get; }
}

public class Program
{
    public static async Task Main()
    {
        Console.WriteLine("Program Start");
        if (false)
        {
            if (true)
            {
                Console.WriteLine("Trace 0");
            }

            try
            {
                for (int i0 = 0; i0 < 3; i0++)
                {
                    i0 = 94;
                    Console.WriteLine("Trace 1");
                }

                try
                {
                    Type_1 v1 = default(Type_1);
                }
                catch (NullReferenceException ex2)
                {
                }
            }
            catch (Exception ex3)
            {
                for (int i4 = 0; i4 < 3; i4++)
                {
                    Type_0 v5 = default(Type_0);
                }
            }

            switch (await System.Threading.Tasks.Task.FromResult(58))
            {
                case 17:
                    string v6 = ("a7669ba9") + ("24762a06");
                    break;
                case 61:
                    for (int i7 = 0; i7 < 3; i7++)
                    {
                        string v8 = "41b5b94f";
                        string v9 = "2a55f500";
                        int v10 = ((2) + (i7)) + (45);
                    }

                    break;
                case 14:
                    await System.Threading.Tasks.Task.CompletedTask;
                    break;
                default:
                    try
                    {
                        int v11 = 63;
                        Type_0 v12 = default(Type_0);
                    }
                    catch (InvalidOperationException ex13)
                    {
                    }

                    break;
            }
        }
        else
        {
            switch ((91) * ((60) * (94)))
            {
                case 97:
                    try
                    {
                        string v14 = "10fdf4ff";
                        bool v15 = false;
                    }
                    catch (Exception ex16)
                    {
                        bool v17 = await await await System.Threading.Tasks.Task.FromResult(System.Threading.Tasks.Task.FromResult(System.Threading.Tasks.Task.FromResult(true)));
                    }

                    try
                    {
                        Console.WriteLine("Trace");
                    }
                    catch (NullReferenceException ex18)
                    {
                        Console.WriteLine("Trace 19");
                    }

                    break;
                case 17:
                    Console.WriteLine("Trace");
                    break;
                default:
                    switch (32)
                    {
                        case 7:
                            Type_2 v19 = new Type_2();
                            bool v20 = true;
                            break;
                        case 4:
                            Type_2 v21 = new Type_2();
                            break;
                        case 32:
                            Type_0 v22 = default(Type_0);
                            Type_1 v23 = default(Type_1);
                            break;
                        default:
                            Type_3 v24 = await System.Threading.Tasks.Task.FromResult(new Type_3());
                            break;
                    }

                    break;
            }

            string v25 = (("264a41d4") + ("00ab9f5d")) + ("032481af");
            switch (v25)
            {
                case "03d259e6":
                    string v26 = "dc95950f";
                    break;
                case "4c5f50b4":
                    try
                    {
                        bool v27 = await System.Threading.Tasks.Task.FromResult(true);
                        Type_0 v28 = default(Type_0);
                    }
                    catch (Exception ex29)
                    {
                        Console.WriteLine("Trace 30");
                    }

                    Type_3 v30 = new Type_3();
                    break;
                default:
                    switch (v25)
                    {
                        case "628a0cff":
                            Type_1 v31 = default(Type_1);
                            break;
                        case "119383bd":
                            Type_4 v32 = default(Type_4);
                            Type_2 v33 = new Type_2();
                            break;
                        case "a16d956e":
                            Type_3 v34 = new Type_3();
                            Type_3 v35 = new Type_3();
                            break;
                        default:
                            Type_2 v36 = new Type_2();
                            break;
                    }

                    break;
            }
        }

        await System.Threading.Tasks.Task.CompletedTask;
        Type_0 v37 = default(Type_0);
        v37 = default(Type_0);
        Type_1 v38 = default(Type_1);
        v38 = default(Type_1);
        v37 = await System.Threading.Tasks.Task.FromResult(default(Type_0));
        await System.Threading.Tasks.Task.CompletedTask;
        Console.WriteLine("Program End");
    }
}