using System;
using System.ComponentModel.DataAnnotations;

namespace Strategies
{
    public class Launch
    {
        public Fairings fairings { get; set; }

        public Links links { get; set; }

        public object static_fire_date_utc { get; set; }
        public object static_fire_date_unix { get; set; }
        public bool tbd { get; set; }
        public bool net { get; set; }
        public object window { get; set; }
        public string rocket { get; set; }
        public bool? success { get; set; }
        public string details { get; set; }
        public object[] crew { get; set; }
        public string[] ships { get; set; }
        public object[] capsules { get; set; }
        public string[] payloads { get; set; }
        public string launchpad { get; set; }
        public bool auto_update { get; set; }
        public string launch_library_id { get; set; }
        public object[] failures { get; set; }
        public int flight_number { get; set; }
        public string name { get; set; }
        public DateTime date_utc { get; set; }
        public int date_unix { get; set; }
        public DateTime date_local { get; set; }
        public string date_precision { get; set; }
        public bool upcoming { get; set; }

        public Core[] cores { get; set; }

        public string id { get; set; }
    }

    public class Fairings
    {
        public bool? reused { get; set; }
        public bool? recovery_attempt { get; set; }
        public object recovered { get; set; }
        public string[] ships { get; set; }
    }

    public class Links
    {
        public Patch patch { get; set; }
        public Reddit reddit { get; set; }
        public Flickr flickr { get; set; }
        public object presskit { get; set; }
        public string webcast { get; set; }
        public string youtube_id { get; set; }
        public object article { get; set; }
        public string wikipedia { get; set; }
    }

    public class Patch
    {
        public string small { get; set; }
        public string large { get; set; }
    }

    public class Reddit
    {
        public string campaign { get; set; }
        public string launch { get; set; }
        public object media { get; set; }
        public string recovery { get; set; }
    }

    public class Flickr
    {
        public object[] small { get; set; }
        public string[] original { get; set; }
    }

    public class Core
    {
        public string core { get; set; }
        public int? flight { get; set; }
        public bool? gridfins { get; set; }
        public bool? legs { get; set; }
        public bool? reused { get; set; }
        public bool? landing_attempt { get; set; }
        public bool? landing_success { get; set; }
        public string landing_type { get; set; }
        public string landpad { get; set; }
    }
}
