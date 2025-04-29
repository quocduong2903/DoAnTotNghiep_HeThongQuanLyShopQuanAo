using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class tai_khoan_sql_BLL
    {
        private tai_khoan_sql_DAL tk_bll;
        public tai_khoan_sql_BLL()
        {
            tk_bll = new tai_khoan_sql_DAL();
        }
        public bool CheckLogin(string tk, string mk, out int userRoleId)
        {
            return tk_bll.CheckLogin(tk, mk, out userRoleId);
        }
        public List<int> GetAccessibleScreens(int userRoleId, out string name)
        {
            return tk_bll.GetAccessibleScreens(userRoleId, out name);
        }
        public int get_id_nv_by_tk(string nametk)
        {
            return tk_bll.get_id_nv_by_tk(nametk);
        }
        public tai_khoan GetTaiKhoanByMaID(int id)
        {
            return tk_bll.GetTaiKhoanByMaNhanVien(id);
        }
        public bool ChangePassword(string userId, string newPassword)
        {
            return tk_bll.ChangePassword(userId, newPassword);
        }
        public List<tai_khoan> GetTaiKhoanByRole(string role)
        {
            return tk_bll.GetTaiKhoanByRole(role);
        }
        public string GetRoleNameByAccountId(int accountId)
        {
            return tk_bll.GetRoleNameByAccountId(accountId);
        }
        public bool UpdateRole(int accountId, string roleName)
        {
            return tk_bll.UpdateRole(accountId, roleName);
        }
    }
}
