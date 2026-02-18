using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

public struct Type_0
{
    public static Type_1<bool> Prop_0 { get; set; }
    public int Prop_1 { get; }

    public interface Type_1<T0>
    {
        string Prop_0 { get; set; }

        abstract Task<int> Method_1(int p0);
    }
}

public struct Type_2 : Type_4
{
    public static int Prop_0 { get; set; }
}

public interface Type_3<T0>
{
    Type_1<string> Prop_0 { get; set; }

    abstract string Method_1(Type_4 p0, string p1);
    abstract void Method_2();
}

public interface Type_4
{
    Type_4 Prop_0 { get; }

    string Prop_1 { get; }

    Type_4 Prop_2 { get; set; }

    abstract Type_1<int> Method_3();
}

public class Program
{
    public static async Task Main()
    {
        Console.WriteLine("Program Start");
        Console.WriteLine("Trace");
        switch (await System.Threading.Tasks.Task.FromResult(23))
        {
            case 38:
                bool v0 = (false) && ((await await System.Threading.Tasks.Task.FromResult(System.Threading.Tasks.Task.FromResult("8cd36a2b"))) == (("ca85c932") + ("e1ada143")));
                break;
            case 26:
                if (await System.Threading.Tasks.Task.FromResult(false))
                {
                    switch (66)
                    {
                        case 11:
                            Type_2 v1 = new Type_2();
                            break;
                        case 10:
                            Type_0 v2 = new Type_0();
                            break;
                        default:
                            int v3 = 69;
                            break;
                    }

                    if (true)
                    {
                        Type_4 v4 = default(Type_4);
                        Type_3<bool> v5 = default(Type_3<bool>);
                    }

                    try
                    {
                        Console.WriteLine("Trace 6");
                    }
                    catch (Exception ex6)
                    {
                        Type_4 v7 = default(Type_4);
                    }
                    finally
                    {
                        int v8 = 65;
                    }
                }

                break;
            default:
                int v9 = 25;
                break;
        }

        for (int i10 = 0; i10 < 4; i10++)
        {
            await System.Threading.Tasks.Task.Yield();
        }

        string v11 = (("6743ed7c") + ((("8b7236c9") + ("2aefa084")) + (("3c5773eb") + ("8a820413")))) + ("881f9f10");
        Console.WriteLine(v11);
        v11 = await System.Threading.Tasks.Task.FromResult("0052f53b");
        Type_2 v12 = new Type_2();
        Console.WriteLine(v11);
        if (await System.Threading.Tasks.Task.FromResult(true))
        {
            Type_2 v13 = new Type_2();
        }

        try
        {
            v12 = new Type_2();
        }
        catch (InvalidOperationException ex14)
        {
            switch (v11)
            {
                case "85056a63":
                    for (int i15 = 0; i15 < 4; i15++)
                    {
                        Type_3<bool> v16 = default(Type_3<bool>);
                        int v17 = i15;
                    }

                    await System.Threading.Tasks.Task.Yield();
                    break;
                case "25e3c409":
                    if (true)
                    {
                        Type_4 v18 = default(Type_4);
                        int v19 = 5;
                        int v20 = 41;
                    }

                    await System.Threading.Tasks.Task.Yield();
                    break;
                default:
                    for (int i21 = 0; i21 < 4; i21++)
                    {
                        Type_2 v22 = new Type_2();
                        int v23 = await System.Threading.Tasks.Task.FromResult(46);
                    }

                    break;
            }
        }
        finally
        {
            try
            {
                Console.WriteLine("Trace 24");
                Console.WriteLine(v11);
            }
            catch (NullReferenceException ex24)
            {
                if (await System.Threading.Tasks.Task.FromResult(false))
                {
                    string v25 = "0983bbf0";
                }
                else
                {
                    Type_0 v26 = new Type_0();
                    int v27 = 83;
                    Type_3<string> v28 = default(Type_3<string>);
                }
            }
        }

        Console.WriteLine("Program End");
    }
}