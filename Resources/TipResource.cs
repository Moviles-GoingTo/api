using System;
using GoingTo_API.Domain.Models;

namespace GoingTo_API.Resources
{
    public class TipResource
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public LocatableResource Locatable { get; set; }
    }
}
