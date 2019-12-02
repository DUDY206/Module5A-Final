using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLL
{
    public class BussinessLayer
    {
        Connection con = new Connection();
        
        
        //////////////////////////////////////////////////
        //Amenitites Query 
        //////////////////////////////////////////////////
        public DataTable GetListAmenities(string tick_id)
        {
            return con.GetListAmenities(tick_id);
        }

        //////////////////////////////////////////////////
        //Amenities Tickets Query
        //////////////////////////////////////////////////
        public void ChangeAmenTick(string ticket_id, string amenity_id, string type, int price)
        {
            con.ChangeAmenTick(ticket_id, amenity_id, type, price);
        }

        public DataTable ReportAmenities(string flight_num)
        {
            return con.ReportAmenities(flight_num);
        }

        //////////////////////////////////////
        //Booking References
        //////////////////////////////////////

        public DataTable GetListTicket(string booking_reference)
        {
            return con.GetListTicket(booking_reference);
        }

        //////////////////////////////////////
        //Cabin
        //////////////////////////////////////

        public DataTable GetListCabin()
        {
            return con.GetListCabin();
        }

        //////////////////////////////////////
        //Schedule
        //////////////////////////////////////
        public bool IsExistFN(string flight_num)
        {
            return con.IsExistFN(flight_num);
        }
        public DataTable GetListFlight(string date_picked)
        {
            return con.GetListFlight(date_picked);
        }

        //////////////////////////////////////
        //Ticket
        //////////////////////////////////////
        ///

        public bool IsInvalidHour(string ticket_id)
        {
            return con.IsInvalidHour(ticket_id);
        }
        public DataTable GetTicketInfo(string ticket_id)
        {
            return con.GetTicketInfo(ticket_id);
        }
    }
}
