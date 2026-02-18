using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

public interface Type_0<T0>
{
    Type_4 Prop_0 { get; set; }
}

public struct Type_1
{
    public Type_0<int> Prop_1 { get; set; }
    public Type_2 Prop_2 { get; set; }
    public int Prop_3 { get; set; }

    public void Method_0(Type_4 p0, string p1, Type_0<string> p2)
    {
        Type_4 v0 = new Type_4();
        Console.WriteLine("TraceObj");
        Console.WriteLine("Trace 1");
        switch (90)
        {
            case 44:
                for (int i1 = 0; i1 < 3; i1++)
                {
                    if (true)
                    {
                        bool v2 = false;
                        Type_0<int> v3 = default(Type_0<int>);
                    }
                    else
                    {
                        bool v4 = (true) && (true);
                        Console.WriteLine("Trace 5");
                    }
                }

                Type_2 v5 = default(Type_2);
                break;
            case 26:
                if (false)
                {
                    p0 = v0;
                    try
                    {
                        Type_3 v6 = new Type_3();
                        string v7 = "b8e9e599";
                    }
                    catch (InvalidOperationException ex8)
                    {
                        int v9 = Type_4.Prop_0;
                    }
                }

                switch ((Type_4.Prop_0) - (75))
                {
                    case 29:
                        Type_1 v10 = new Type_1();
                        switch (14)
                        {
                            case 61:
                                int v11 = 72;
                                break;
                            case 97:
                                Console.WriteLine("Trace 12");
                                return;
                                break;
                            default:
                                Type_4 v12 = new Type_4();
                                break;
                        }

                        return;
                        break;
                    case 11:
                        for (int i13 = 0; i13 < 3; i13++)
                        {
                            i13 = i13;
                            Type_4 v14 = new Type_4();
                            int v15 = 49;
                        }

                        return;
                        break;
                    default:
                        Type_2 v16 = default(Type_2);
                        break;
                }

                break;
            default:
                switch (45)
                {
                    case 64:
                        Type_4 v17 = new Type_4();
                        break;
                    case 96:
                        Type_2 v18 = default(Type_2);
                        break;
                    case 50:
                        Console.WriteLine("TraceObj");
                        break;
                    default:
                        if (false)
                        {
                            string v19 = Type_3.Method_2(("4a6a44ea") + ("8a3d9483"), default(Type_0<string>));
                        }

                        break;
                }

                break;
        }

        switch (37)
        {
            case 50:
                try
                {
                    Console.WriteLine("TraceObj");
                    switch (p1)
                    {
                        case "0ce3c9ad":
                            Type_2 v20 = default(Type_2);
                            return;
                            break;
                        case "d9aecfb7":
                            Console.WriteLine("TraceObj");
                            Console.WriteLine("TraceObj");
                            break;
                        case "5eb45aa3":
                            Console.WriteLine("TraceObj");
                            bool v21 = true;
                            break;
                        default:
                            Type_1 v22 = v0.Method_1(new Type_4(), p1, new Type_3());
                            break;
                    }
                }
                catch (NullReferenceException ex23)
                {
                    Console.WriteLine("TraceObj");
                }

                break;
            case 19:
                v0 = new Type_4();
                string v24 = "882fc18d";
                break;
            case 67:
                try
                {
                    try
                    {
                        Type_0<bool> v25 = default(Type_0<bool>);
                    }
                    catch (NullReferenceException ex26)
                    {
                        bool v27 = true;
                        return;
                    }

                    try
                    {
                        int v28 = 15;
                    }
                    catch (Exception ex29)
                    {
                        int v30 = this.Prop_3;
                        return;
                    }
                }
                catch (InvalidOperationException ex31)
                {
                    if (false)
                    {
                        string v32 = (p1) + ("1e822c0f");
                        Console.WriteLine("TraceObj");
                        Type_0<bool> v33 = default(Type_0<bool>);
                    }
                }

                string v34 = "2710e26e";
                return;
                break;
            default:
                switch (p1)
                {
                    case "4b576c23":
                        switch (39)
                        {
                            case 78:
                                bool v35 = ("1bb7a915") == ("27c05995");
                                break;
                            case 69:
                                Type_0<string> v36 = default(Type_0<string>);
                                break;
                            case 59:
                                string v37 = ("b8d2ba86") + ("649912c0");
                                return;
                                break;
                            default:
                                int v38 = Type_4.Prop_0;
                                break;
                        }

                        switch (75)
                        {
                            case 77:
                                p2 = default(Type_0<string>);
                                break;
                            case 16:
                                break;
                            default:
                                int v39 = 67;
                                break;
                        }

                        break;
                    case "609a767b":
                        Console.WriteLine("TraceObj");
                        break;
                    default:
                        Type_3 v40 = new Type_3();
                        break;
                }

                break;
        }

        return;
    }
}

public abstract class Type_2
{
    public static Type_4 Method_0(bool p0, Type_1 p1)
    {
        p0 = true;
        for (int i41 = 0; i41 < 3; i41++)
        {
            if (false)
            {
                Console.WriteLine(i41);
                return new Type_4();
            }

            for (int i42 = 0; i42 < 3; i42++)
            {
                for (int i43 = 0; i43 < 4; i43++)
                {
                    Type_4 v44 = Type_2.Method_0(p0, new Type_1());
                    return Type_2.Method_0(p0, new Type_1());
                }

                return new Type_4();
            }

            Console.WriteLine("Trace 45");
            return new Type_4();
        }

        if (false)
        {
            Console.WriteLine("Trace 45");
            Type_1 v45 = new Type_1();
            return new Type_4();
        }

        Type_4 v46 = new Type_4();
        v46 = new Type_4();
        return v46;
    }
}

public struct Type_3
{
    public Type_4 Method_0(Type_4 p0, string p1, Type_2 p2)
    {
        Type_3 v47 = new Type_3();
        Type_1 v48 = new Type_1();
        switch (v48.Prop_3)
        {
            case 11:
                switch (99)
                {
                    case 48:
                        bool v49 = true;
                        return new Type_4();
                        break;
                    case 23:
                        try
                        {
                            Type_2 v50 = Type_4.Prop_2;
                            return p0;
                        }
                        catch (InvalidOperationException ex51)
                        {
                            bool v52 = false;
                            return new Type_4();
                        }
                        finally
                        {
                            Type_3 v53 = new Type_3();
                        }

                        bool v54 = true;
                        return Type_2.Method_0(false, new Type_1());
                        break;
                    default:
                        for (int i55 = 0; i55 < 4; i55++)
                        {
                            p1 = "0bb646f7";
                            string v56 = "09fcaa26";
                            bool v57 = false;
                            return new Type_4();
                        }

                        return p0;
                        break;
                }

                try
                {
                    for (int i58 = 0; i58 < 4; i58++)
                    {
                        Console.WriteLine("Trace 59");
                        return p0;
                    }

                    return new Type_4();
                }
                catch (InvalidOperationException ex59)
                {
                    string v60 = p1;
                    return Type_2.Method_0(("e26d3d0a") == (v60), p0.Method_1(new Type_4(), v60, v47));
                }

                return new Type_4();
                break;
            case 37:
                switch (p1)
                {
                    case "181beec8":
                        try
                        {
                            Type_4 v61 = v47.Method_0(new Type_4(), "f6eb25c1", default(Type_2));
                            return p0;
                        }
                        catch (NullReferenceException ex62)
                        {
                            string v63 = "ff632a40";
                            return Type_2.Method_0(false, v48);
                        }
                        finally
                        {
                            Console.WriteLine("Trace 64");
                        }

                        Console.WriteLine("Trace 64");
                        return new Type_4();
                        break;
                    case "b8aa7fec":
                        try
                        {
                            Console.WriteLine("Trace 64");
                            string v64 = "07ccb5b2";
                            return new Type_4();
                        }
                        catch (Exception ex65)
                        {
                            Type_3 v66 = new Type_3();
                            return new Type_4();
                        }

                        for (int i67 = 0; i67 < 2; i67++)
                        {
                            int v68 = 93;
                            bool v69 = false;
                            return p0;
                        }

                        return new Type_4();
                        break;
                    case "01ded658":
                        Console.WriteLine("Trace 70");
                        p2 = p2;
                        return p0;
                        break;
                    default:
                        if ((default(Type_0<bool>)) == (default(Type_0<bool>)))
                        {
                            Type_2 v70 = default(Type_2);
                            string v71 = p1;
                            return new Type_4();
                        }

                        return new Type_4();
                        break;
                }

                return p0;
                break;
            default:
                switch (40)
                {
                    case 23:
                        Console.WriteLine("Trace 72");
                        return new Type_4();
                        break;
                    case 20:
                        try
                        {
                            int v72 = 22;
                            p0 = new Type_4();
                            return new Type_4();
                        }
                        catch (NullReferenceException ex73)
                        {
                            string v74 = (p1) + ("a96aba0a");
                            return p0;
                        }

                        return new Type_4();
                        break;
                    case 28:
                        if (true)
                        {
                            Type_2 v75 = v48.Prop_2;
                            Type_4 v76 = new Type_4();
                            return new Type_4();
                        }

                        return new Type_4();
                        break;
                    default:
                        for (int i77 = 0; i77 < 4; i77++)
                        {
                            Type_4 v78 = this.Method_0(new Type_4(), "483fb5c1", default(Type_2));
                            return Type_2.Method_0(true, new Type_1());
                        }

                        return this.Method_0(new Type_4(), Type_3.Method_2("879571cb", default(Type_0<string>)), p2);
                        break;
                }

                return new Type_4();
                break;
        }

        try
        {
            Type_2 v79 = default(Type_2);
            Type_4 v80 = new Type_4();
            return new Type_4();
        }
        catch (Exception ex81)
        {
            if (true)
            {
                v48 = new Type_1();
                for (int i82 = 0; i82 < 3; i82++)
                {
                    Type_0<string> v83 = default(Type_0<string>);
                    Type_4 v84 = new Type_4();
                    return new Type_4();
                }

                return p0;
            }
            else
            {
                for (int i85 = 0; i85 < 2; i85++)
                {
                    string v86 = "7ecc2774";
                    Console.WriteLine("Trace 87");
                    return new Type_4();
                }

                bool v87 = false;
                Type_1 v88 = new Type_1();
                return new Type_4();
            }

            return new Type_4();
        }
        finally
        {
            for (int i89 = 0; i89 < 4; i89++)
            {
                Console.WriteLine("Trace 90");
                if (true)
                {
                    Console.WriteLine("TraceObj");
                }

                string v90 = Type_3.Method_2("c5e2d7b3", default(Type_0<string>));
            }
        }

        switch (v47.Method_1(90))
        {
            case 3:
                Type_0<bool> v91 = default(Type_0<bool>);
                switch (v48.Prop_3)
                {
                    case 40:
                        v47 = new Type_3();
                        return new Type_4();
                        break;
                    case 41:
                        Type_3 v92 = new Type_3();
                        switch (((35) * ((54) - (98))) - (90))
                        {
                            case 12:
                                string v93 = (p1) + (("0d752a9f") + ("9dc78c05"));
                                return new Type_4();
                                break;
                            case 23:
                                Type_2 v94 = p2;
                                return Type_2.Method_0(true, new Type_1());
                                break;
                            case 52:
                                Type_3 v95 = v47;
                                return new Type_4();
                                break;
                            default:
                                Type_3 v96 = new Type_3();
                                return new Type_4();
                                break;
                        }

                        return new Type_4();
                        break;
                    case 43:
                        string v97 = ("2089ab2c") + ((p1) + ("31fc9855"));
                        if ((true) && (true))
                        {
                            int v98 = (84) * (52);
                            return p0;
                        }

                        return new Type_4();
                        break;
                    default:
                        if (false)
                        {
                            Console.WriteLine("Trace 99");
                            Type_0<int> v99 = default(Type_0<int>);
                            bool v100 = false;
                            return new Type_4();
                        }
                        else
                        {
                            int v101 = 30;
                            return new Type_4();
                        }

                        return new Type_4();
                        break;
                }

                return Type_2.Method_0(true, v48);
                break;
            case 1:
                for (int i102 = 0; i102 < 2; i102++)
                {
                    if (true)
                    {
                        Console.WriteLine(p1);
                        Console.WriteLine("TraceObj");
                        Type_4 v103 = new Type_4();
                        return new Type_4();
                    }

                    if (true)
                    {
                        int v104 = (37) - (90);
                        return p0;
                    }
                    else
                    {
                        Console.WriteLine("TraceObj");
                        return new Type_4();
                    }

                    return Type_2.Method_0(true, p0.Method_1(new Type_4(), p1, new Type_3()));
                }

                return new Type_4();
                break;
            default:
                switch (78)
                {
                    case 73:
                        Type_4 v105 = new Type_4();
                        return new Type_4();
                        break;
                    case 70:
                        try
                        {
                            v47 = v47;
                            Console.WriteLine("TraceObj");
                            return new Type_4();
                        }
                        catch (NullReferenceException ex106)
                        {
                            Type_0<int> v107 = default(Type_0<int>);
                            return new Type_4();
                        }

                        return Type_2.Method_0(true, new Type_1());
                        break;
                    case 45:
                        Type_1 v108 = new Type_1();
                        return new Type_4();
                        break;
                    default:
                        for (int i109 = 0; i109 < 3; i109++)
                        {
                            string v110 = "bec4224f";
                            return new Type_4();
                        }

                        return p0;
                        break;
                }

                return new Type_4();
                break;
        }

        return new Type_4();
    }

    public int Method_1(int p0)
    {
        p0 = 4;
        Console.WriteLine(p0);
        for (int i111 = 0; i111 < 2; i111++)
        {
            try
            {
                switch (p0)
                {
                    case 18:
                        Type_0<string> v112 = default(Type_0<string>);
                        return (i111) * (78);
                        break;
                    case 20:
                        Type_4 v113 = new Type_4();
                        return Type_4.Prop_0;
                        break;
                    case 35:
                        return 59;
                        break;
                    default:
                        Type_1 v114 = new Type_1();
                        return 58;
                        break;
                }

                if (true)
                {
                    int v115 = this.Method_1(Type_4.Prop_0);
                    bool v116 = true;
                    return 90;
                }

                return Type_4.Prop_0;
            }
            catch (InvalidOperationException ex117)
            {
                return ((36) + (i111)) + (59);
            }

            try
            {
                if (((73) * (Type_4.Prop_0)) < (this.Method_1(i111)))
                {
                    p0 = 99;
                    int v118 = this.Method_1(i111);
                    Console.WriteLine("Trace 119");
                    return 34;
                }
                else
                {
                    bool v119 = false;
                    return 41;
                }

                return i111;
            }
            catch (InvalidOperationException ex120)
            {
                try
                {
                    string v121 = "90ad3e34";
                    int v122 = 27;
                    return (87) - (49);
                }
                catch (ArgumentException ex123)
                {
                    Type_2 v124 = default(Type_2);
                    return 16;
                }

                return i111;
            }
            finally
            {
                for (int i125 = 0; i125 < 3; i125++)
                {
                    string v126 = (((Type_3.Method_2("3cba4829", default(Type_0<string>))) + ("765e3903")) + ("6157496f")) + ("c71b20ca");
                }
            }

            Console.WriteLine("Trace 127");
            return p0;
        }

        Console.WriteLine("Trace 127");
        return Type_4.Prop_0;
    }

    public static string Method_2(string p0, Type_0<string> p1)
    {
        int v127 = 1;
        switch (35)
        {
            case 68:
                p0 = Type_3.Method_2("e925429f", default(Type_0<string>));
                return "df77f79f";
                break;
            case 3:
                for (int i128 = 0; i128 < 3; i128++)
                {
                    try
                    {
                        Type_0<string> v129 = default(Type_0<string>);
                        int v130 = 83;
                        return "b7612dba";
                    }
                    catch (InvalidOperationException ex131)
                    {
                        int v132 = 36;
                        return (p0) + (p0);
                    }

                    switch (19)
                    {
                        case 51:
                            Console.WriteLine("TraceObj");
                            return Type_3.Method_2(p0, p1);
                            break;
                        case 45:
                            Type_1 v133 = new Type_1();
                            Console.WriteLine(i128);
                            return Type_3.Method_2("5fe4555c", default(Type_0<string>));
                            break;
                        default:
                            Type_4 v134 = new Type_4();
                            return "3ca0ad70";
                            break;
                    }

                    return "0869dcf8";
                }

                Type_1 v135 = new Type_1();
                return "4fa7a272";
                break;
            default:
                Console.WriteLine("Trace 136");
                return Type_3.Method_2(p0, default(Type_0<string>));
                break;
        }

        int v136 = 60;
        Type_0<bool> v137 = default(Type_0<bool>);
        int v138 = 91;
        return p0;
    }

    public async Task<Type_4> Method_3()
    {
        await System.Threading.Tasks.Task.Yield();
        try
        {
            if (false)
            {
                try
                {
                    Type_4 v139 = this.Method_0(new Type_4(), "f32ad121", default(Type_2));
                    return new Type_4();
                }
                catch (NullReferenceException ex140)
                {
                    Type_1 v141 = await System.Threading.Tasks.Task.FromResult(new Type_1());
                    return new Type_4();
                }

                string v142 = await System.Threading.Tasks.Task.FromResult("ab46ae3e");
                Console.WriteLine("Trace 143");
                return await System.Threading.Tasks.Task.FromResult(new Type_4());
            }
            else
            {
                Console.WriteLine("Trace 143");
                return new Type_4();
            }

            return new Type_4();
        }
        catch (Exception ex143)
        {
            if (true)
            {
                for (int i144 = 0; i144 < 4; i144++)
                {
                    int v145 = (this.Method_1(80)) + (await System.Threading.Tasks.Task.FromResult(55));
                    string v146 = "67ecaae3";
                    return this.Method_0(new Type_4(), v146, default(Type_2));
                }

                return new Type_4();
            }
            else
            {
                try
                {
                    Type_0<bool> v147 = default(Type_0<bool>);
                    return new Type_4();
                }
                catch (Exception ex148)
                {
                    string v149 = "cff105e5";
                    return new Type_4();
                }

                switch (await System.Threading.Tasks.Task.FromResult(67))
                {
                    case 61:
                        Type_4 v150 = new Type_4();
                        int v151 = 16;
                        return Type_2.Method_0(false, new Type_1());
                        break;
                    case 68:
                        bool v152 = await System.Threading.Tasks.Task.FromResult(false);
                        v152 = await await System.Threading.Tasks.Task.FromResult(System.Threading.Tasks.Task.FromResult(false));
                        return new Type_4();
                        break;
                    default:
                        Console.WriteLine("Trace 153");
                        return new Type_4();
                        break;
                }

                return await System.Threading.Tasks.Task.FromResult(new Type_4());
            }

            return new Type_4();
        }

        await System.Threading.Tasks.Task.CompletedTask;
        switch (this.Method_1(await System.Threading.Tasks.Task.FromResult(17)))
        {
            case 40:
                switch ((73) + (36))
                {
                    case 51:
                        for (int i153 = 0; i153 < 4; i153++)
                        {
                            string v154 = "27c2d69c";
                            int v155 = await System.Threading.Tasks.Task.FromResult(87);
                            return await System.Threading.Tasks.Task.FromResult(new Type_4());
                        }

                        return new Type_4();
                        break;
                    case 14:
                        Console.WriteLine("Trace 156");
                        for (int i156 = 0; i156 < 3; i156++)
                        {
                            Type_4 v157 = new Type_4();
                            bool v158 = false;
                            Type_1 v159 = new Type_1();
                            return v157;
                        }

                        return new Type_4();
                        break;
                    default:
                        for (int i160 = 0; i160 < 2; i160++)
                        {
                            Type_0<int> v161 = default(Type_0<int>);
                            return new Type_4();
                        }

                        return new Type_4();
                        break;
                }

                return new Type_4();
                break;
            case 21:
                try
                {
                    try
                    {
                        return new Type_4();
                    }
                    catch (NullReferenceException ex162)
                    {
                        Console.WriteLine("Trace 163");
                        return Type_2.Method_0(false, new Type_1());
                    }

                    return new Type_4();
                }
                catch (ArgumentException ex163)
                {
                    await System.Threading.Tasks.Task.CompletedTask;
                    return new Type_4();
                }

                return this.Method_0(new Type_4(), "e687d467", default(Type_2));
                break;
            default:
                try
                {
                    await System.Threading.Tasks.Task.CompletedTask;
                    return await System.Threading.Tasks.Task.FromResult(new Type_4());
                }
                catch (Exception ex164)
                {
                    Type_4 v165 = new Type_4();
                    return new Type_4();
                }

                return new Type_4();
                break;
        }

        return new Type_4();
    }
}

public struct Type_4
{
    public static int Prop_0 { get; set; }
    public static Type_2 Prop_2 { get; set; }

    public Type_1 Method_1(Type_4 p0, string p1, Type_3 p2)
    {
        p0 = new Type_4();
        for (int i166 = 0; i166 < 2; i166++)
        {
            i166 = 47;
            Type_1 v167 = this.Method_1(new Type_4(), "ebc60b15", new Type_3());
            if (true)
            {
                Console.WriteLine("TraceObj");
                try
                {
                    bool v168 = true;
                    return new Type_1();
                }
                catch (InvalidOperationException ex169)
                {
                    string v170 = ("bff203f5") + ("056ccbcb");
                    return new Type_1();
                }

                Console.WriteLine("Trace 171");
                return p0.Method_1(Type_2.Method_0(true, v167), "e63be401", new Type_3());
            }

            return new Type_1();
        }

        switch (28)
        {
            case 24:
                string v171 = Type_3.Method_2("a2645238", default(Type_0<string>));
                return p0.Method_1(new Type_4(), Type_3.Method_2(Type_3.Method_2("bfc0305d", default(Type_0<string>)), default(Type_0<string>)), p2);
                break;
            case 48:
                try
                {
                    try
                    {
                        Type_3 v172 = new Type_3();
                        Console.WriteLine("Trace 173");
                        return new Type_1();
                    }
                    catch (NullReferenceException ex173)
                    {
                        bool v174 = false;
                        return new Type_1();
                    }

                    return new Type_1();
                }
                catch (ArgumentException ex175)
                {
                    Type_0<bool> v176 = default(Type_0<bool>);
                    return new Type_1();
                }
                finally
                {
                    if (true)
                    {
                        bool v177 = true;
                        int v178 = 18;
                    }
                    else
                    {
                        Type_0<bool> v179 = default(Type_0<bool>);
                    }
                }

                return p0.Method_1(this, ((p1) + ("33f8103e")) + ("f78a2f4d"), new Type_3());
                break;
            default:
                p0 = new Type_4();
                return new Type_1()
                {
                    Prop_2 = default(Type_2)
                };
                break;
        }

        Console.WriteLine("Trace 180");
        Type_4 v180 = new Type_4();
        return new Type_1();
    }
}

public class Program
{
    public static async Task Main()
    {
        Console.WriteLine("Program Start");
        switch (61)
        {
            case 41:
                if (false)
                {
                    for (int i0 = 0; i0 < 2; i0++)
                    {
                        int v1 = (await System.Threading.Tasks.Task.FromResult(64)) * (i0);
                        Console.WriteLine("Trace 2");
                    }

                    await System.Threading.Tasks.Task.Yield();
                }
                else
                {
                }

                break;
            case 2:
                if (true)
                {
                    try
                    {
                        int v2 = (64) - (await System.Threading.Tasks.Task.FromResult(11));
                        Console.WriteLine("Trace 3");
                    }
                    catch (InvalidOperationException ex3)
                    {
                        Console.WriteLine("Trace");
                    }
                }
                else
                {
                    await System.Threading.Tasks.Task.Yield();
                }

                break;
            default:
                Console.WriteLine("Trace 4");
                break;
        }

        try
        {
            try
            {
                switch (98)
                {
                    case 80:
                        bool v4 = false;
                        string v5 = Type_3.Method_2(await System.Threading.Tasks.Task.FromResult("fcbb79d3"), default(Type_0<string>));
                        break;
                    case 84:
                        string v6 = "fefec954";
                        break;
                    default:
                        string v7 = await System.Threading.Tasks.Task.FromResult("a2aedd38");
                        break;
                }

                Console.WriteLine("Trace 8");
            }
            catch (ArgumentException ex8)
            {
                await System.Threading.Tasks.Task.CompletedTask;
            }
            finally
            {
                Type_3 v9 = new Type_3();
            }
        }
        catch (Exception ex10)
        {
            try
            {
                Console.WriteLine("Trace");
            }
            catch (ArgumentException ex11)
            {
                if (await System.Threading.Tasks.Task.FromResult(false))
                {
                    Type_3 v12 = new Type_3();
                    Type_2 v13 = default(Type_2);
                }
                else
                {
                    Type_3 v14 = await System.Threading.Tasks.Task.FromResult(new Type_3());
                    string v15 = "b71b82d1";
                    bool v16 = true;
                }
            }
        }

        for (int i17 = 0; i17 < 4; i17++)
        {
            i17 = await await System.Threading.Tasks.Task.FromResult(System.Threading.Tasks.Task.FromResult(17));
        }

        Console.WriteLine("Trace 18");
        await System.Threading.Tasks.Task.CompletedTask;
        for (int i18 = 0; i18 < 4; i18++)
        {
            string v19 = "9c8e6120";
        }

        await System.Threading.Tasks.Task.CompletedTask;
        for (int i20 = 0; i20 < 4; i20++)
        {
            Console.WriteLine("Trace 21");
            Console.WriteLine(i20);
            Console.WriteLine("Trace 21");
        }

        Console.WriteLine("Program End");
    }
}