namespace CRUD_API.Models
{
	public class ComplexFilter
	{
		public AgeFilter AgeFilter { get; set; }
		public SexFilter SexFilter { get; set; }
		public OwnerParameters OwnerParameters { get; set; }
	}
}
