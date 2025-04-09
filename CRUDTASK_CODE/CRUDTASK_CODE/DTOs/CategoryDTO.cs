namespace CRUDTASK_CODE.DTOs
{
    public class CategoryDTO
    {

        public int CategoryId { get; set; }
        public string Name { get; set; }

        public List<ProductDTO> Products { get; set; }
    }
}
