namespace PPM.Model
{
public interface IEntityOperation<T>
{
    public void AddEntity(T entity);
    public List<T> ListAll();
    public T ListById(int id);
    public bool Delete(int id);
}

}
 