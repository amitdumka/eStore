﻿using System;
using System.Linq;
using eStore.DL.Data;
using eStore.Shared.Models.Tailoring;
using Microsoft.EntityFrameworkCore;

namespace eStore.BL.Tailoring
{
    public class TailoringManager
    {
        public void OnUpdateData(eStoreDbContext db, TalioringDelivery delivery, bool isEdit, bool isDelete = false)
        {

            TalioringBooking booking = db.TalioringBookings.Find(delivery.TalioringBookingId);
            //Updating Booking for Delivery Status. 
            if (isEdit)
            {
                if (booking != null)
                {
                    var oldId = db.TailoringDeliveries.Where(c => c.TalioringDeliveryId == delivery.TalioringDeliveryId).Select(c => new { c.TalioringBookingId }).FirstOrDefault();
                    if (oldId.TalioringBookingId != delivery.TalioringBookingId)
                    {
                        TalioringBooking old = db.TalioringBookings.Find(oldId.TalioringBookingId);
                        old.IsDelivered = false;
                        booking.IsDelivered = true;
                        db.Entry(booking).State = EntityState.Modified;
                        db.Entry(old).State = EntityState.Modified;
                    }
                }
            }
            else
            {
                if (booking != null)
                {
                    if (isDelete)
                    {
                        booking.IsDelivered = false;
                    }
                    else
                    {
                        booking.IsDelivered = true;
                    }
                    db.Entry(booking).State = EntityState.Modified;
                }
            }


        }
    }
}