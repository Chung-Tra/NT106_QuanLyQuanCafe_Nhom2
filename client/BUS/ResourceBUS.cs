using DAL;
using DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BUS
{
    // Thin BUS wrappers cho các node RTDB dùng chung backend generic resource API.
    // Mỗi lớp chỉ khai báo path + DTO, tái sử dụng ResourceDAL.

    public static class TableBUS
    {
        const string P = "tables";
        public static Task<Dictionary<string, TableDTO>> GetAll() => ResourceDAL.GetAllAsync<TableDTO>(P);
        public static Task<(bool, string, string?)> Add(TableDTO d) => ResourceDAL.AddAsync(P, d);
        public static Task<(bool, string)> Update(string id, object d) => ResourceDAL.UpdateAsync(P, id, d);
        public static Task<(bool, string)> Delete(string id) => ResourceDAL.DeleteAsync(P, id);
    }

    public static class OrderBUS
    {
        const string P = "orders";
        public static Task<Dictionary<string, OrderDTO>> GetAll() => ResourceDAL.GetAllAsync<OrderDTO>(P);
        public static Task<(bool, string, string?)> Add(OrderDTO d) => ResourceDAL.AddAsync(P, d);
        public static Task<(bool, string)> Update(string id, object d) => ResourceDAL.UpdateAsync(P, id, d);
        public static Task<(bool, string)> Delete(string id) => ResourceDAL.DeleteAsync(P, id);
    }

    public static class PaymentBUS
    {
        const string P = "payments";
        public static Task<Dictionary<string, PaymentDTO>> GetAll() => ResourceDAL.GetAllAsync<PaymentDTO>(P);
        public static Task<(bool, string, string?)> Add(PaymentDTO d) => ResourceDAL.AddAsync(P, d);
        public static Task<(bool, string)> Update(string id, object d) => ResourceDAL.UpdateAsync(P, id, d);
        public static Task<(bool, string)> Delete(string id) => ResourceDAL.DeleteAsync(P, id);
    }

    public static class CustomerBUS
    {
        const string P = "customers";
        public static Task<Dictionary<string, CustomerDTO>> GetAll() => ResourceDAL.GetAllAsync<CustomerDTO>(P);
        public static Task<(bool, string, string?)> Add(CustomerDTO d) => ResourceDAL.AddAsync(P, d);
        public static Task<(bool, string)> Update(string id, object d) => ResourceDAL.UpdateAsync(P, id, d);
        public static Task<(bool, string)> Delete(string id) => ResourceDAL.DeleteAsync(P, id);
    }

    public static class FeedbackBUS
    {
        const string P = "feedback";
        public static Task<Dictionary<string, FeedbackDTO>> GetAll() => ResourceDAL.GetAllAsync<FeedbackDTO>(P);
        public static Task<(bool, string, string?)> Add(FeedbackDTO d) => ResourceDAL.AddAsync(P, d);
        public static Task<(bool, string)> Update(string id, object d) => ResourceDAL.UpdateAsync(P, id, d);
        public static Task<(bool, string)> Delete(string id) => ResourceDAL.DeleteAsync(P, id);
    }

    public static class AttendanceBUS
    {
        const string P = "attendance";
        public static Task<Dictionary<string, AttendanceDTO>> GetAll() => ResourceDAL.GetAllAsync<AttendanceDTO>(P);
        public static Task<(bool, string, string?)> Add(AttendanceDTO d) => ResourceDAL.AddAsync(P, d);
        public static Task<(bool, string)> Update(string id, object d) => ResourceDAL.UpdateAsync(P, id, d);
        public static Task<(bool, string)> Delete(string id) => ResourceDAL.DeleteAsync(P, id);
    }

    public static class PointLogBUS
    {
        const string P = "point-logs";
        public static Task<Dictionary<string, PointLogDTO>> GetAll() => ResourceDAL.GetAllAsync<PointLogDTO>(P);
        public static Task<(bool, string, string?)> Add(PointLogDTO d) => ResourceDAL.AddAsync(P, d);
        public static Task<(bool, string)> Update(string id, object d) => ResourceDAL.UpdateAsync(P, id, d);
        public static Task<(bool, string)> Delete(string id) => ResourceDAL.DeleteAsync(P, id);
    }

    public static class SalaryBUS
    {
        const string P = "salaries";
        public static Task<Dictionary<string, SalaryDTO>> GetAll() => ResourceDAL.GetAllAsync<SalaryDTO>(P);
        public static Task<(bool, string, string?)> Add(SalaryDTO d) => ResourceDAL.AddAsync(P, d);
        public static Task<(bool, string)> Update(string id, object d) => ResourceDAL.UpdateAsync(P, id, d);
        public static Task<(bool, string)> Delete(string id) => ResourceDAL.DeleteAsync(P, id);
    }

    public static class LeaveRequestBUS
    {
        const string P = "leave-requests";
        public static Task<Dictionary<string, LeaveRequestDTO>> GetAll() => ResourceDAL.GetAllAsync<LeaveRequestDTO>(P);
        public static Task<(bool, string, string?)> Add(LeaveRequestDTO d) => ResourceDAL.AddAsync(P, d);
        public static Task<(bool, string)> Update(string id, object d) => ResourceDAL.UpdateAsync(P, id, d);
        public static Task<(bool, string)> Delete(string id) => ResourceDAL.DeleteAsync(P, id);
    }

    public static class NotificationBUS
    {
        const string P = "notifications";
        public static Task<Dictionary<string, NotificationDTO>> GetAll() => ResourceDAL.GetAllAsync<NotificationDTO>(P);
        public static Task<(bool, string, string?)> Add(NotificationDTO d) => ResourceDAL.AddAsync(P, d);
        public static Task<(bool, string)> Update(string id, object d) => ResourceDAL.UpdateAsync(P, id, d);
        public static Task<(bool, string)> Delete(string id) => ResourceDAL.DeleteAsync(P, id);
    }

    public static class ParkingBUS
    {
        const string P = "parking";
        public static Task<Dictionary<string, ParkingDTO>> GetAll() => ResourceDAL.GetAllAsync<ParkingDTO>(P);
        public static Task<(bool, string, string?)> Add(ParkingDTO d) => ResourceDAL.AddAsync(P, d);
        public static Task<(bool, string)> Update(string id, object d) => ResourceDAL.UpdateAsync(P, id, d);
        public static Task<(bool, string)> Delete(string id) => ResourceDAL.DeleteAsync(P, id);
    }

    public static class IncidentBUS
    {
        const string P = "incidents";
        public static Task<Dictionary<string, IncidentDTO>> GetAll() => ResourceDAL.GetAllAsync<IncidentDTO>(P);
        public static Task<(bool, string, string?)> Add(IncidentDTO d) => ResourceDAL.AddAsync(P, d);
        public static Task<(bool, string)> Update(string id, object d) => ResourceDAL.UpdateAsync(P, id, d);
        public static Task<(bool, string)> Delete(string id) => ResourceDAL.DeleteAsync(P, id);
    }

    public static class WarningBUS
    {
        const string P = "warnings";
        public static Task<Dictionary<string, WarningDTO>> GetAll() => ResourceDAL.GetAllAsync<WarningDTO>(P);
        public static Task<(bool, string, string?)> Add(WarningDTO d) => ResourceDAL.AddAsync(P, d);
        public static Task<(bool, string)> Update(string id, object d) => ResourceDAL.UpdateAsync(P, id, d);
        public static Task<(bool, string)> Delete(string id) => ResourceDAL.DeleteAsync(P, id);
    }

    public static class RecipeBUS
    {
        const string P = "recipes";
        public static Task<Dictionary<string, RecipeDTO>> GetAll() => ResourceDAL.GetAllAsync<RecipeDTO>(P);
        public static Task<(bool, string, string?)> Add(RecipeDTO d) => ResourceDAL.AddAsync(P, d);
        public static Task<(bool, string)> Update(string id, object d) => ResourceDAL.UpdateAsync(P, id, d);
        public static Task<(bool, string)> Delete(string id) => ResourceDAL.DeleteAsync(P, id);
    }

    // ---- Node MỚI cho các màn phụ ----

    public static class PromotionBUS
    {
        const string P = "promotions";
        public static Task<Dictionary<string, PromotionDTO>> GetAll() => ResourceDAL.GetAllAsync<PromotionDTO>(P);
        public static Task<(bool, string, string?)> Add(PromotionDTO d) => ResourceDAL.AddAsync(P, d);
        public static Task<(bool, string)> Update(string id, object d) => ResourceDAL.UpdateAsync(P, id, d);
        public static Task<(bool, string)> Delete(string id) => ResourceDAL.DeleteAsync(P, id);
    }

    public static class ExpenseBUS
    {
        const string P = "expenses";
        public static Task<Dictionary<string, ExpenseDTO>> GetAll() => ResourceDAL.GetAllAsync<ExpenseDTO>(P);
        public static Task<(bool, string, string?)> Add(ExpenseDTO d) => ResourceDAL.AddAsync(P, d);
        public static Task<(bool, string)> Update(string id, object d) => ResourceDAL.UpdateAsync(P, id, d);
        public static Task<(bool, string)> Delete(string id) => ResourceDAL.DeleteAsync(P, id);
    }

    public static class LossBUS
    {
        const string P = "losses";
        public static Task<Dictionary<string, LossDTO>> GetAll() => ResourceDAL.GetAllAsync<LossDTO>(P);
        public static Task<(bool, string, string?)> Add(LossDTO d) => ResourceDAL.AddAsync(P, d);
        public static Task<(bool, string)> Update(string id, object d) => ResourceDAL.UpdateAsync(P, id, d);
        public static Task<(bool, string)> Delete(string id) => ResourceDAL.DeleteAsync(P, id);
    }

    public static class ReservationBUS
    {
        const string P = "reservations";
        public static Task<Dictionary<string, ReservationDTO>> GetAll() => ResourceDAL.GetAllAsync<ReservationDTO>(P);
        public static Task<(bool, string, string?)> Add(ReservationDTO d) => ResourceDAL.AddAsync(P, d);
        public static Task<(bool, string)> Update(string id, object d) => ResourceDAL.UpdateAsync(P, id, d);
        public static Task<(bool, string)> Delete(string id) => ResourceDAL.DeleteAsync(P, id);
    }

    public static class AuditLogBUS
    {
        const string P = "audit-logs";
        public static Task<Dictionary<string, AuditLogDTO>> GetAll() => ResourceDAL.GetAllAsync<AuditLogDTO>(P);
        public static Task<(bool, string, string?)> Add(AuditLogDTO d) => ResourceDAL.AddAsync(P, d);
        public static Task<(bool, string)> Update(string id, object d) => ResourceDAL.UpdateAsync(P, id, d);
        public static Task<(bool, string)> Delete(string id) => ResourceDAL.DeleteAsync(P, id);
    }

    public static class BroadcastBUS
    {
        const string P = "broadcasts";
        public static Task<Dictionary<string, BroadcastDTO>> GetAll() => ResourceDAL.GetAllAsync<BroadcastDTO>(P);
        public static Task<(bool, string, string?)> Add(BroadcastDTO d) => ResourceDAL.AddAsync(P, d);
        public static Task<(bool, string)> Update(string id, object d) => ResourceDAL.UpdateAsync(P, id, d);
        public static Task<(bool, string)> Delete(string id) => ResourceDAL.DeleteAsync(P, id);
    }

    public static class ScheduleBUS
    {
        const string P = "schedules";
        public static Task<Dictionary<string, ScheduleDTO>> GetAll() => ResourceDAL.GetAllAsync<ScheduleDTO>(P);
        public static Task<(bool, string, string?)> Add(ScheduleDTO d) => ResourceDAL.AddAsync(P, d);
        public static Task<(bool, string)> Update(string id, object d) => ResourceDAL.UpdateAsync(P, id, d);
        public static Task<(bool, string)> Delete(string id) => ResourceDAL.DeleteAsync(P, id);
    }

    public static class ShiftBUS
    {
        const string P = "shift-registers";
        public static Task<Dictionary<string, ShiftDTO>> GetAll() => ResourceDAL.GetAllAsync<ShiftDTO>(P);
        public static Task<(bool, string, string?)> Add(ShiftDTO d) => ResourceDAL.AddAsync(P, d);
        public static Task<(bool, string)> Update(string id, object d) => ResourceDAL.UpdateAsync(P, id, d);
        public static Task<(bool, string)> Delete(string id) => ResourceDAL.DeleteAsync(P, id);
    }

    public static class BugReportBUS
    {
        const string P = "bug-reports";
        public static Task<Dictionary<string, BugReportDTO>> GetAll() => ResourceDAL.GetAllAsync<BugReportDTO>(P);
        public static Task<(bool, string, string?)> Add(BugReportDTO d) => ResourceDAL.AddAsync(P, d);
        public static Task<(bool, string)> Update(string id, object d) => ResourceDAL.UpdateAsync(P, id, d);
        public static Task<(bool, string)> Delete(string id) => ResourceDAL.DeleteAsync(P, id);
    }
}
