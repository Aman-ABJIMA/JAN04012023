try
{
    IEnumerable<Worker> data = Workers.TestData;
    int[] colWidths = GetColumnWidths(data, 4);
    foreach(string row in FormatGridRows(data,colWidths))Console.WriteLine(row);
    //foreach (Worker worker in Workers.TestData)
    //Console.WriteLine(worker);
}
catch (Exception e)
{
    Console.WriteLine($"ERROR: {e.Message}");
}
int[] GetColumnWidths(IEnumerable<Worker>data,int Count)
{
    int[] colWidths= new int[Count];
    int Index = 0;
    foreach(Worker item in data)
    {
        colWidths[Index] = Math.Max(item.ToString().Length, colWidths[Index]);
        Index = (Index + 1) % Count;
    }
    return colWidths;  
}
IEnumerable<string> FormatGridRows(IEnumerable<Worker> data, int[] colWidths)
{
    StringBuilder row = new();
    int Index = 0;
    foreach(Worker item in data)
    {
        row.Append(item.ToString().PadRight(colWidths[Index]+2));
        Index = (Index+1) % colWidths.Length;
        if(Index==0)
        {
            yield return row.ToString().TrimEnd();
            row.Clear();
        }
    }
    if(row.Length> 0) yield return row.ToString().TrimEnd(); 
}