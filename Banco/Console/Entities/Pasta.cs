namespace Entities
{
    public class Pasta
    {
       
        public string Obj { get; set; }
        public double Value { get; set; }
        public double Meta { get; set; }
        
       

        public double Total { get { return Meta - Value; } }
      
        public Pasta(){}
        public Pasta(string obj)
        {
            Obj = obj;
        }
        
        public Pasta(string obj,double value,double meta) :this(obj)
        {   
           
            Value = value;
            Meta = meta; 
        }

        public override bool Equals(object obj)
        {
            if(!(obj is Pasta))
            {
                return false;
            }
            Pasta other = obj as Pasta;
            return this.Obj.Equals(other.Obj);         
            
        }

        public override int GetHashCode()
        {
            return this.Obj.GetHashCode();           
        }
}
}