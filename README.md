# CheatSheets

Cheat sheets for my reference when writing new ASP.NET Core projects. 


Most of this is just static extension methods to save me the job of rewriting the same code in different projects: 
E.g.

 public static decimal RemoveTrailingZeros(this decimal input) => 
            decimal.Parse(input.ToString("0.#######", new System.Globalization.CultureInfo("en-US")), new System.Globalization.CultureInfo("en-US"));




# read a file 
FileStream fileStream = new FileStream("./pp-2017.csv", FileMode.Open);
using (StreamReader reader = new StreamReader(fileStream))
{
    string line;
    while ((line = reader.ReadLine()) != null){
        var split = line.Split(",");
        # process file in here 
    }
}


# reflection 
public string GetPropertyByName<T>(T obj, string name ){
   return obj.GetType().GetProperties(name)?.GetValue(obj); 
}


public List<Tuple<string,object>> GetAllPropertyValues<T>(T obj){
   var list = new List<Tuple<string,string>>();
   foreach(var property in obj.GetType().GetProperties()){
       var tuple = new Tuple<string, object>(property.Name, property.GetValue(obj));
       list.Add(tuple);
   }
   return list;
}

public List<string> GetCommmonProperties<T1,T2>(T1 obj1, T2 obj2){
   var obj1Names = obj1.GetType().GetProperties().Select(s => s.Name);
   var obj2Names = obj2.GetType().GetProperties().Select(s => s.Name);
   return obj1Names.Where(n => obj2Names.Contains(n)).ToList();
}

