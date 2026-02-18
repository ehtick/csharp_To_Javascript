using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

public struct Type_0<T0>
{
    public string Prop_0 { get; set; }
    public int Prop_1 { get; set; }
}

public interface Type_1
{
    abstract Type_2 Method_0(string p0, int p1);
}

public struct Type_2
{
    public static Type_1 Prop_0 { get; set; }
}

public class Type_3 : Type_1
{
    public bool Prop_0 { get; set; }

    public Type_2 Method_0(string p0, int p1)
    {
        Console.WriteLine(p1);
        Type_4 v0 = new Type_4();
        Console.WriteLine("TraceObj");
        v0 = new Type_4()
        {
            Prop_1 = new Type_0<bool>(),
            Prop_0 = true
        };
        return new Type_2();
    }
}

public struct Type_4
{
    public bool Prop_0 { get; set; }
    public Type_0<bool> Prop_1 { get; set; }

    public bool Method_2(Type_0<int> p0)
    {
        if (false)
        {
            if ((p0.Prop_0) == ("2272d546"))
            {
                for (int i1 = 0; i1 < 4; i1++)
                {
                    int v2 = i1;
                    return (true) && (true);
                }

                return false;
            }
            else
            {
                string v3 = "8f7fe21b";
                if (false)
                {
                    Type_1 v4 = default(Type_1);
                    string v5 = "f38d006d";
                    return false;
                }

                return false;
            }

            Type_0<bool> v6 = new Type_0<bool>();
            return true;
        }
        else
        {
            try
            {
                string v7 = p0.Prop_0;
                if (true)
                {
                    Type_3 v8 = new Type_3();
                    Type_0<int> v9 = new Type_0<int>();
                    Type_0<int> v10 = new Type_0<int>();
                    return (21) < (38);
                }

                return false;
            }
            catch (Exception ex11)
            {
                Console.WriteLine("Trace 12");
                return this.Method_2(new Type_0<int>());
            }
            finally
            {
                try
                {
                    bool v12 = false;
                }
                catch (ArgumentException ex13)
                {
                    bool v14 = true;
                }
            }

            p0 = new Type_0<int>();
            return false;
        }

        for (int i15 = 0; i15 < 4; i15++)
        {
            for (int i16 = 0; i16 < 3; i16++)
            {
                bool v17 = false;
                return this.Prop_0;
            }

            for (int i18 = 0; i18 < 3; i18++)
            {
                try
                {
                    p0 = new Type_0<int>();
                    int v19 = p0.Prop_1;
                    return true;
                }
                catch (Exception ex20)
                {
                    Type_2 v21 = new Type_2();
                    return true;
                }

                Type_4 v22 = new Type_4();
                if (false)
                {
                    string v23 = "33747b0b";
                    return true;
                }

                return false;
            }

            try
            {
                switch (i15)
                {
                    case 25:
                        int v24 = p0.Prop_1;
                        int v25 = (23) * (79);
                        return (true) && (false);
                        break;
                    case 93:
                        p0 = new Type_0<int>();
                        p0 = new Type_0<int>();
                        return false;
                        break;
                    default:
                        Type_3 v26 = new Type_3();
                        return false;
                        break;
                }

                return this.Method_2(p0);
            }
            catch (InvalidOperationException ex27)
            {
                switch (52)
                {
                    case 6:
                        string v28 = p0.Prop_0;
                        return this.Prop_0;
                        break;
                    case 67:
                        int v29 = i15;
                        bool v30 = (this.Prop_0) && (false);
                        return v30;
                        break;
                    case 56:
                        Type_3 v31 = new Type_3();
                        Type_4 v32 = new Type_4();
                        return true;
                        break;
                    default:
                        Type_3 v33 = new Type_3();
                        return false;
                        break;
                }

                return true;
            }

            return false;
        }

        Console.WriteLine("Trace 34");
        p0 = new Type_0<int>();
        if (this.Prop_0)
        {
            if (false)
            {
                if (this.Method_2(new Type_0<int>()))
                {
                    Type_3 v34 = new Type_3();
                    Type_0<bool> v35 = new Type_0<bool>();
                    return false;
                }
                else
                {
                    string v36 = "411856af";
                    string v37 = "72d4d62a";
                    bool v38 = this.Prop_0;
                    return v38;
                }

                switch (((14) + (72)) - (15))
                {
                    case 33:
                        Type_1 v39 = default(Type_1);
                        string v40 = "9551f647";
                        return true;
                        break;
                    case 70:
                        int v41 = (60) * (p0.Prop_1);
                        v41 = (74) * (v41);
                        return this.Method_2(p0);
                        break;
                    case 55:
                        int v42 = 57;
                        Type_4 v43 = this;
                        return true;
                        break;
                    default:
                        Type_0<bool> v44 = new Type_0<bool>();
                        return true;
                        break;
                }

                Type_2 v45 = new Type_2();
                return true;
            }

            Console.WriteLine("Trace 46");
            return false;
        }

        return true;
    }
}

public class Program
{
    public static async Task Main()
    {
        Console.WriteLine("Program Start");
        try
        {
            Console.WriteLine("Trace 0");
            Console.WriteLine("Trace 0");
        }
        catch (ArgumentException ex0)
        {
            try
            {
                try
                {
                    Type_0<int> v1 = new Type_0<int>();
                }
                catch (InvalidOperationException ex2)
                {
                    bool v3 = (false) && (false);
                }
            }
            catch (ArgumentException ex4)
            {
                try
                {
                    string v5 = await System.Threading.Tasks.Task.FromResult("1342c443");
                }
                catch (ArgumentException ex6)
                {
                    Console.WriteLine("Trace");
                }
            }
        }

        switch (await System.Threading.Tasks.Task.FromResult(13))
        {
            case 21:
                for (int i7 = 0; i7 < 4; i7++)
                {
                    await System.Threading.Tasks.Task.CompletedTask;
                    Console.WriteLine(i7);
                    switch (i7)
                    {
                        case 30:
                            Type_3 v8 = new Type_3();
                            break;
                        case 60:
                            bool v9 = true;
                            bool v10 = true;
                            break;
                        default:
                            Type_1 v11 = default(Type_1);
                            break;
                    }
                }

                break;
            case 44:
                Type_0<bool> v12 = new Type_0<bool>();
                break;
            default:
                break;
        }

        for (int i13 = 0; i13 < 4; i13++)
        {
            i13 = i13;
            if (true)
            {
                Console.WriteLine(i13);
            }
        }

        if ((("825905f9") == ((await System.Threading.Tasks.Task.FromResult("f5ef3fd6")) + ("e8de6e7e"))) && (false))
        {
            if (await await System.Threading.Tasks.Task.FromResult(System.Threading.Tasks.Task.FromResult(true)))
            {
                for (int i14 = 0; i14 < 2; i14++)
                {
                    Console.WriteLine(i14);
                    int v15 = 19;
                }

                switch ((99) * (42))
                {
                    case 2:
                        Console.WriteLine("Trace 16");
                        string v16 = (await await System.Threading.Tasks.Task.FromResult(System.Threading.Tasks.Task.FromResult("66435622"))) + ("e28cb91f");
                        break;
                    case 35:
                        int v17 = 11;
                        break;
                    case 49:
                        int v18 = await System.Threading.Tasks.Task.FromResult(79);
                        Type_1 v19 = default(Type_1);
                        break;
                    default:
                        bool v20 = true;
                        break;
                }

                Console.WriteLine("Trace");
            }
            else
            {
                for (int i21 = 0; i21 < 2; i21++)
                {
                    string v22 = "0572ac68";
                    Console.WriteLine(i21);
                }

                switch (30)
                {
                    case 63:
                        bool v23 = await System.Threading.Tasks.Task.FromResult(true);
                        break;
                    case 56:
                        string v24 = (await System.Threading.Tasks.Task.FromResult("571ef2f8")) + (("94c821ed") + (("cebbccfe") + (await System.Threading.Tasks.Task.FromResult("6fe170e1"))));
                        int v25 = (((44) * (7)) * (12)) + ((58) + (27));
                        break;
                    default:
                        bool v26 = false;
                        break;
                }
            }
        }
        else
        {
            if (false)
            {
                switch (((((36) + (62)) * (75)) * (29)) * (27))
                {
                    case 67:
                        string v27 = "a97c825d";
                        v27 = v27;
                        break;
                    case 0:
                        break;
                    case 48:
                        Type_4 v28 = new Type_4();
                        break;
                    default:
                        Console.WriteLine("Trace 29");
                        break;
                }
            }
            else
            {
                await System.Threading.Tasks.Task.CompletedTask;
                Type_4 v29 = await System.Threading.Tasks.Task.FromResult(new Type_4());
            }
        }

        Type_3 v30 = new Type_3();
        for (int i31 = 0; i31 < 2; i31++)
        {
            for (int i32 = 0; i32 < 4; i32++)
            {
                string v33 = ("a7210073") + (await System.Threading.Tasks.Task.FromResult("cadef267"));
                if (false)
                {
                    Console.WriteLine(i32);
                    i32 = (76) - (i31);
                }

                i32 = 61;
            }
        }

        await System.Threading.Tasks.Task.CompletedTask;
        await System.Threading.Tasks.Task.CompletedTask;
        v30 = new Type_3();
        Console.WriteLine("Program End");
    }
}