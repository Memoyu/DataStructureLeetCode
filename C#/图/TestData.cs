namespace 图;

public static class TestData
{
    public static object[][] BFS_01 =
    {
        new object[] { "A", "B" }, new object[] { "A", "F" },
        new object[] { "B", "C" }, new object[] { "B", "I" }, new object[] { "B", "G" },
        new object[] { "C", "I" }, new object[] { "C", "D" },
        new object[] { "D", "I" }, new object[] { "D", "G" }, new object[] { "D", "E" }, new object[] { "D", "H" },
        new object[] { "E", "H" }, new object[] { "E", "F" },
        new object[] { "F", "G" },
        new object[] { "G", "H" },
    };

    public static object[][] BFS_02 =
    {
        new object[] { 0, 1 }, new object[] { 0, 4 },
        new object[] { 1, 2 },
        new object[] { 2, 0 }, new object[] { 2, 4 }, new object[] { 2, 5 },
        new object[] { 3, 1 },
        new object[] { 4, 6 }, new object[] { 4, 7 },
        new object[] { 5, 3 }, new object[] { 5, 7 },
        new object[] { 6, 2 }, new object[] { 6, 7 }
    };

    public static object[][] BFS_03 =
    {
        new object[] { 0, 2 }, new object[] { 0, 3 },
        new object[] { 1, 2 }, new object[] { 1, 3 }, new object[] { 1, 6 },
        new object[] { 2, 4 },
        new object[] { 3, 7 },
        new object[] { 4, 6 },
        new object[] { 5, 6 },
        new object[] { 6, 7 }
    };

    public static object[][] BFS_04 =
    {
        new object[] { 1, 2 }, new object[] { 1, 3 }, new object[] { 1, 5 },
        new object[] { 2, 0 },
        new object[] { 3, 5 },
        new object[] { 5, 6 }, new object[] { 5, 7 },
        new object[] { 6, 2 },
        new object[] { 7, 6 }
    };

    public static object[][] DFS_01 =
    {
        new object[] { 0, 1 },
        new object[] { 1, 3 }, new object[] { 1, 5 }, new object[] { 1, 6 }, new object[] { 1, 2 },
        new object[] { 2, 4 },
        new object[] { 3, 7 }
    };

    public static object[][] DFS_02 =
    {
        new object[] { "a", "b" }, new object[] { "a", "e" },
        new object[] { "b", "e" },
        new object[] { "c", "b" },
        new object[] { "d", "a" },
        new object[] { "e", "c" }, new object[] { "e", "f" },
        new object[] { "f", "c" }
    };

    public static object[][] TOPO =
    {
        new object[] { 0, 2 },
        new object[] { 1, 0 },
        new object[] { 2, 5 }, new object[] { 2, 6 },
        new object[] { 3, 1 }, new object[] { 3, 5 }, new object[] { 3, 7 },
        new object[] { 5, 7 },
        new object[] { 6, 4 },
        new object[] { 7, 6 }
    };

    public static object[][] NO_WEIGHT2 =
    {
        new object[] { 0, 3 },
        new object[] { 1, 3 }, new object[] { 1, 6 },
        new object[] { 2, 1 },
        new object[] { 3, 5 },
        new object[] { 6, 2 }, new object[] { 6, 5 },
        new object[] { 4, 7 }
    };

    public static object[][] NO_WEIGHT3 =
    {
        new object[] { 0, 1 }, new object[] { 0, 2 },
        new object[] { 1, 2 }, new object[] { 1, 5 },
        new object[] { 2, 4 }, new object[] { 2, 5 },
        new object[] { 5, 6 }, new object[] { 7, 6 },
        new object[] { 3 }
    };

    public static object[][] MST_01 =
    {
        new object[] { 0, 2, 2 }, new object[] { 0, 4, 7 },
        new object[] { 1, 2, 3 }, new object[] { 1, 5, 1 }, new object[] { 1, 6, 7 },
        new object[] { 2, 4, 4 }, new object[] { 2, 5, 3 }, new object[] { 2, 6, 6 },
        new object[] { 3, 7, 9 },
        new object[] { 4, 6, 8 },
        new object[] { 5, 6, 4 }, new object[] { 5, 7, 5 }
    };

    public static object[][] MST_02 =
    {
        new object[] { "A", "B", 17 }, new object[] { "A", "F", 1 }, new object[] { "A", "E", 16 },
        new object[] { "B", "C", 6 }, new object[] { "B", "D", 5 }, new object[] { "B", "F", 11 },
        new object[] { "C", "D", 10 },
        new object[] { "D", "E", 4 }, new object[] { "D", "F", 14 },
        new object[] { "E", "F", 33 }
    };

    public static object[][] WEIGHT3 =
    {
        new object[] { "广州", "佛山", 100 }, new object[] { "广州", "珠海", 200 }, new object[] { "广州", "肇庆", 200 },
        new object[] { "佛山", "珠海", 50 }, new object[] { "佛山", "深圳", 150 },
        new object[] { "肇庆", "珠海", 100 }, new object[] { "肇庆", "南宁", 150 },
        new object[] { "珠海", "南宁", 350 }, new object[] { "珠海", "深圳", 100 },
        new object[] { "南宁", "香港", 500 }, new object[] { "南宁", "深圳", 400 },
        new object[] { "深圳", "香港", 150 }
    };

    public static object[][] SP =
    {
        new object[] { "A", "B", 10 }, new object[] { "A", "D", 30 }, new object[] { "A", "E", 100 },
        new object[] { "B", "C", 50 },
        new object[] { "C", "E", 10 },
        new object[] { "D", "C", 20 }, new object[] { "D", "E", 60 }
    };

    public static object[][] BF_SP =
    {
        new object[] { "A", "B", 10 }, new object[] { "A", "E", 8 },
        new object[] { "B", "C", 8 }, new object[] { "B", "E", -5 },
        new object[] { "D", "C", 2 }, new object[] { "D", "F", 6 },
        new object[] { "E", "D", 7 }, new object[] { "E", "F", 3 }
    };

    public static object[][] WEIGHT5 =
    {
        new object[] { 0, 14, 1 }, new object[] { 0, 4, 8 },
        new object[] { 1, 2, 9 },
        new object[] { 2, 3, 6 }, new object[] { 2, 5, 9 },
        new object[] { 3, 17, 1 }, new object[] { 3, 10, 4 },
        new object[] { 4, 5, 2 }, new object[] { 4, 8, 2 },
        new object[] { 5, 6, 6 }, new object[] { 5, 8, 1 }, new object[] { 5, 9, 4 },
        new object[] { 6, 9, 8 },
        new object[] { 7, 11, 4 },
        new object[] { 8, 9, 1 }, new object[] { 8, 11, 2 }, new object[] { 8, 12, 7 },
        new object[] { 9, 10, 7 }, new object[] { 9, 13, 4 },
        new object[] { 10, 13, 2 },
        new object[] { 11, 12, 7 }, new object[] { 11, 15, 4 },
        new object[] { 12, 13, 2 }, new object[] { 12, 16, 2 },
        new object[] { 13, 16, 7 },
        new object[] { 15, 16, 7 }, new object[] { 15, 17, 7 },
        new object[] { 16, 17, 2 }
    };

    public static object[][] NEGATIVE_WEIGHT1 =
    {
        new object[] { "A", "B", -1 }, new object[] { "A", "C", 4 },
        new object[] { "B", "C", 3 }, new object[] { "B", "D", 2 }, new object[] { "B", "E", 2 },
        new object[] { "D", "B", 1 }, new object[] { "D", "C", 5 },
        new object[] { "E", "D", -3 }
    };


    /// <summary>
    /// 有负权环
    /// </summary>
    public static object[][] NEGATIVE_WEIGHT2 =
    {
        new object[] { 0, 1, 1 },
        new object[] { 1, 2, 7 },
        new object[] { 1, 0, -2 }
    };
}