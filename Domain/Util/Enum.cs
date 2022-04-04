using System.ComponentModel.DataAnnotations;

namespace Domain.Util
{
 
    public enum ProcessingTypeEnum
    {
        [Display(Name = "N/A", Description = "N/A")]
        NA = 0,
        [Display(Name = "EXPIRED", Description = "EXPIRED")]
        EXPIRED = 1,
        [Display(Name = "MEDIUMRISK", Description = "MEDIUMRISK")]
        MEDIUMRISK = 2,
        [Display(Name = "HIGHRISK", Description = "HIGHRISK")]
        HIGHRISK = 3
    }

    public enum ClientTypeEnum
    {

        [Display(Name = "Private", Description = "Private")]
        PRIVATE = 1,
        [Display(Name = "Public", Description = "Public")]
        PUBLIC = 2,
    }

}
