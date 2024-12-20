namespace SignalR.EntityLayer.Entities
{
    public class Testimonial
    {
        public int TestimonialID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public int ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}
