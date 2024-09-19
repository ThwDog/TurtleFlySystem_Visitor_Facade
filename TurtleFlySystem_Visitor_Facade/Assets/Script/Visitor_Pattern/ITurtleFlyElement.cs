public interface ITurtleFlyElement // or IVisitable
{
    void Accept(IVisitor visitor); 
}
