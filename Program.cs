string inputtext = File.ReadAllText("input.txt");

string[] inputlines = inputtext.Split('\n');

List<List<(int, int)>> lines = new List<List<(int, int)>>();

//List<(int, (int, int))> traversedpoints = new List<(int, (int, int))>();

Dictionary<(int, int), int> traversedpoints  = new Dictionary<(int, int), int>();

for (int i = 0; i < inputlines.Length; i++)
{
    lines.Add(new List<(int, int)>());
    string[] tmppoint = inputlines[i].Split("->");
    for(int j = 0; j<tmppoint.Length; j++)
    {
        string[] tmp = tmppoint[j].Split(',');
        lines[i].Add((int.Parse(tmp[0]),int.Parse(tmp[1])));
    }
}

traversepoints(traversedpoints, lines);

Console.WriteLine(overlappingpoints(traversedpoints));

/// <summary>
/// Traverse through the paths diagonally aswell and horizontal/vertical
/// </summary>
void traversepoints(Dictionary<(int, int),int> traversedpoints, List<List<(int,int)>> lines)
{
    foreach (var line in lines)
    {
        int deltax = line[1].Item1 - line[0].Item1,
            deltay = line[1].Item2 - line[0].Item2;
        (int x, int y) = line[0];

        if (deltax != 0 && deltay != 0)
        {
            if (Math.Min(Math.Abs(deltax), Math.Abs(deltay)) == deltax)
            {
                for (int i = 0; i < Math.Abs(deltax); i++)
                {
                    if (traversedpoints.ContainsKey((x, y)))
                    {
                        traversedpoints[(x, y)]++;
                    }
                    else
                    {
                        traversedpoints.Add((x, y), 1);
                    }
                    if(deltax > 0)
                    {
                        x++;
                        if (deltay > 0)
                            y++;
                        else
                            y--;
                    }
                    else if(deltay < 0)
                    {
                        x--;
                        if (deltay > 0)
                            y++;
                        else
                            y--;
                    }
                    
                }
            }
            else
            {
                for (int i = 0; i < Math.Abs(deltay) + 1; i++)
                {
                    if (traversedpoints.ContainsKey((x, y)))
                    {
                        traversedpoints[(x, y)]++;
                    }
                    else
                    {
                        traversedpoints.Add((x, y), 1);
                    }
                    if (deltax > 0)
                    {
                        x++;
                        if (deltay > 0)
                            y++;
                        else
                            y--;
                    }
                    else if (deltay < 0)
                    {
                        x--;
                        if (deltay > 0)
                            y++;
                        else
                            y--;
                    }
                }
            }
        }
        Console.WriteLine((deltax, deltay));
        if (deltax != 0 && deltay == 0)
        {
            for (int i = 0; i < Math.Abs(deltax) + 1; i++)
            {
                if (traversedpoints.ContainsKey((x, y)))
                {

                    traversedpoints[(x, y)]++;
                }
                else
                {
                    traversedpoints.Add((x, y), 1);
                }
                if (deltax < 0)
                    x--;
                else if (deltax > 0)
                    x++;
            }
        }
        else if(deltay != 0 && deltax == 0)
        {
            for (int i = 0; i < Math.Abs(deltay) + 1; i++)
            {
                if (traversedpoints.ContainsKey((x, y)))
                {
                    traversedpoints[(x, y)]++;
                }
                else
                {
                    traversedpoints.Add((x, y), 1);
                }
                if (deltay < 0)
                    y--;
                else if (deltay > 0)
                    y++;
            }
        }
    }
}
/// <summary>
/// 
/// </summary>
/// <param name="points">A dictionary to put the unique points that we go through in</param>
/// <param name="lines">A 2d list of the start and end points of the lines</param>
void traversepointspart1(Dictionary<(int, int), int> points, List<List<(int, int)>> lines)
{
    foreach (var line in lines)
    {
        if (line[0].Item1 == line[1].Item1)
        {
            int len = line[1].Item2 - line[0].Item2;
            (int x, int y) = line[0];
            for (int i = 0; i < Math.Abs(len) + 1; i++)
            {
                if (traversedpoints.ContainsKey((x, y)))
                {
                    traversedpoints[(x, y)]++;
                }
                else
                {
                    traversedpoints.Add((x, y), 1);
                }
                if (len < 0)
                    y--;
                else if (len > 0)
                    y++;
            }
        }
        else if (line[0].Item2 == line[1].Item2)
        {
            int len = line[1].Item1 - line[0].Item1;
            Console.WriteLine(len);
            (int x, int y) = line[0];
            for (int i = 0; i < Math.Abs(len) + 1; i++)
            {
                if (traversedpoints.ContainsKey((x, y)))
                {
                    
                    traversedpoints[(x, y)]++;
                }
                else
                { 
                    traversedpoints.Add((x, y), 1);
                }
                if (len < 0)
                    x--;
                else if (len > 0)
                    x++;
            }
        }
    }
}

int overlappingpoints(Dictionary<(int, int), int> points)
{
    //var matches = points.Where(item => item.Value >= 2);
    int countlargerthantwo = 0;
    foreach (var point in points)
    {
        if(point.Value >= 2)
        {
            countlargerthantwo++;
        }
    }
    
    return countlargerthantwo;
}