using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DiningManagementSystem.com.infy.persistence.DAO;

namespace DiningManagementSystem.com.infy.persistence.Gateway
{
    public class MemberCodeEntryGateway : DBGateway
    {
        private List<MemberEntry> memberCodeList;

        public string save(MemberEntry aMemberEntry)
        {
            try
            {
                aSqlConnection.Open();
                SqlCommand command = new SqlCommand("USPInsertIntoMemberCode", aSqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@memberName", aMemberEntry.name);
                command.Parameters.AddWithValue("@roomNo", aMemberEntry.roomNo);
                command.Parameters.AddWithValue("@address", aMemberEntry.address);
                command.Parameters.AddWithValue("@dateOfEntry", aMemberEntry.dateOfEntry);
                int effectedRows = command.ExecuteNonQuery();
                if (effectedRows > 0)
                {
                    return "Member saved successfully.";
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
            finally
            {
                if (aSqlConnection != null && aSqlConnection.State == ConnectionState.Open)
                {
                    aSqlConnection.Close();
                }
            }
            return "Error while saving member.";
        }

        public System.Collections.Generic.List<DAO.MemberEntry> getMemberCodeInfo()
        {
            try
            {
                aSqlConnection.Open();
                SqlCommand command = new SqlCommand("uspMembers", aSqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader aReader = command.ExecuteReader();
                memberCodeList = new List<MemberEntry>();
                if (aReader.HasRows)
                {
                    while (aReader.Read())
                    {
                        MemberEntry aMemberEntry = new MemberEntry();
                        aMemberEntry.memberId = Convert.ToInt32(aReader[0].ToString());
                        aMemberEntry.name = aReader[1].ToString();
                        aMemberEntry.roomNo = aReader[2].ToString();
                        aMemberEntry.address = aReader[3].ToString();
                        aMemberEntry.dateOfEntry = (DateTime)aReader[4];
                        memberCodeList.Add(aMemberEntry);
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                if (aSqlConnection != null && aSqlConnection.State == ConnectionState.Open)
                {
                    aSqlConnection.Close();
                }
            }
            return memberCodeList;
        }

        public string deleteAll(string myId)
        {
            try
            {
                {
                    aSqlConnection.Open();
                    SqlCommand command = new SqlCommand("USPDeletionOfMember",aSqlConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@memberId",myId);
                    int effectedRows = command.ExecuteNonQuery();
                    if (effectedRows > 0)
                    {
                        return "Member deleted successfully.";
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                aSqlConnection.Close();
            }
            return "Error while deleting member.";
        }

        public string update(MemberEntry aMemberEntry)
        {
            try
            {
                aSqlConnection.Open();
                SqlCommand command = new SqlCommand("USPMemberInfoUpdation", aSqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@memberId", aMemberEntry.memberId);
                command.Parameters.AddWithValue("@memberName", aMemberEntry.name);
                command.Parameters.AddWithValue("@roomNo", aMemberEntry.roomNo);
                command.Parameters.AddWithValue("@address", aMemberEntry.address);
                command.Parameters.AddWithValue("@dateOfEntry", aMemberEntry.dateOfEntry);
                int effectedRows = command.ExecuteNonQuery();
                if (effectedRows > 0)
                {
                    return @"Memeber Information is updated";
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if (aSqlConnection != null && aSqlConnection.State == ConnectionState.Open)
                {
                    aSqlConnection.Close();
                }
            }
            return "Error while updating member.";
        }
    }
}
