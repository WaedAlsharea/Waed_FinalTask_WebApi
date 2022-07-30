using Dapper;
using learn.core.Data;
using learn.core.Domain;
using learn.core.DTO;
using learn.core.Repository;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace learn.infra.Repository
{
   public class FriendshipRepository: IFriendshipRepository
    {

        private readonly IDBContext dbContext;
        public FriendshipRepository(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public bool createFriendship(FriendShipApi friend)
        {
            IEnumerable<FriendShipApi> friends = dbContext.dbConnection.Query<FriendShipApi>("FriendShipApi_package.getallFriendShipApi", commandType: CommandType.StoredProcedure);
          //Check if the users are already friends or not
            if (friends.Any(f => f.acceptId == friend.acceptId && f.requestId == friend.requestId || f.acceptId == friend.requestId && f.acceptId == friend.requestId))
                return false;
            else
            {

                var parameter = new DynamicParameters();
                parameter.Add("senderOfFriendShip", friend.requestId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                parameter.Add("reciverOfFriendShip", friend.acceptId, dbType: DbType.Int32, direction: ParameterDirection.Input);

                var result = dbContext.dbConnection.ExecuteAsync("FriendShipApi_package.createFriendShipApi", parameter, commandType: CommandType.StoredProcedure);
                if (result != null)
                    return true;
                return false;
            }
        }

        public bool deleteFriendship(int id)
        {
            IEnumerable<FriendShipApi> friends = dbContext.dbConnection.Query<FriendShipApi>("FriendShipApi_package.getallFriendShipApi", commandType: CommandType.StoredProcedure);
            if (friends.Any(f => f.fshipId == id))
            {
                var parameter = new DynamicParameters();
                parameter.Add("idOfFriendship", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

                var result = dbContext.dbConnection.ExecuteAsync("FriendShipApi_package.deleteFriendShipApi", parameter, commandType: CommandType.StoredProcedure);
                if (result != null)
                    return true;
                return false;
            }
            else
                return false;

        }

        public List<FriendShipApi> getFriendship()
        {
            IEnumerable<FriendShipApi> friends = dbContext.dbConnection.Query<FriendShipApi>("FriendShipApi_package.getallFriendShipApi", commandType: CommandType.StoredProcedure);
            return friends.ToList();
        }

        public bool BlockUser(FriendShipApi friend , int blockerId)
        {
            bool Is_BlockDone = false;
            IEnumerable<FriendShipApi> friends = dbContext.dbConnection.Query<FriendShipApi>("FriendShipApi_package.getallFriendShipApi", commandType: CommandType.StoredProcedure);
            var relation = friends.Where(f => f.requestId == friend.requestId && f.acceptId == friend.acceptId).SingleOrDefault();
            IEnumerable<UsersDTO> users = dbContext.dbConnection.Query<UsersDTO>("FriendShipApi_package.getUsers", commandType: CommandType.StoredProcedure);
            var blocker = users.Where(u => u.userId == blockerId).SingleOrDefault();


            if (relation != null && relation.Is_Blocked!=1)
            {

                var parameter = new DynamicParameters();

                parameter.Add("senderOfFriendShip", friend.requestId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                parameter.Add("reciverOfFriendShip", friend.acceptId, dbType: DbType.Int32, direction: ParameterDirection.Input);

                var result = dbContext.dbConnection.ExecuteAsync("FriendShipApi_package.blockUserApi", parameter, commandType: CommandType.StoredProcedure);
                if (result != null)
                    Is_BlockDone = true;
                else Is_BlockDone = false;


                if (blockerId == friend.acceptId && Is_BlockDone)
                {
                    var blocked = users.Where(u => u.userId == friend.requestId).SingleOrDefault();
                    bool sent = SendEmail(blocked.Email, blocked.userName, blocker.userName);
                    return sent;



                }
                else if (Is_BlockDone)
                {
                    var blocked = users.Where(u => u.userId == friend.acceptId).SingleOrDefault();
                    bool sent = SendEmail(blocked.Email, blocked.userName, blocker.userName);
                    return sent;
                }

            
            }
             return Is_BlockDone;
        }
        public bool SendEmail(string blockedEmail ,string blockedName ,string blockerName)
        {


            MimeMessage message = new MimeMessage();
            BodyBuilder builder = new BodyBuilder();
            MailboxAddress from = new MailboxAddress("Waed", "wshareaa@gmail.com");
            MailboxAddress to = new MailboxAddress(blockedName, blockedEmail);
            builder.HtmlBody = "<!DOCTYPE html>" +
                  "<html> " +
                     "<body style=\"margin-top: 20px;\"> " +
                     "<table class=\"body - wrap\" style=\"font-family:'Helvetica Neue',Helvetica,Arial,sans - serif; box - sizing: border - box; font - size: 14px; width: 100 %; background - color: #f6f6f6; margin: 0;\" bgcolor=\"#f6f6f6;\">" +
                     "<tbody>" +
                     "<tr style=\"font-family:\'Helvetica Neue',Helvetica,Arial,sans - serif; box - sizing: border - box; font - size: 14px; margin: 0; \">" +
                     "<td style=\"font-family:\'Helvetica Neue',Helvetica,Arial,sans - serif; box - sizing: border - box; font - size: 14px; vertical - align: top; margin: 0; \" valign=\"top\">" + "</td>" +
                     "<td class=\"container\"width=\"600\"style=\"font-family:\'Helvetica Neue',Helvetica,Arial,sans - serif; box - sizing: border - box; font - size: 14px; display: block!important; max - width: 600px!important; clear: both!important; margin: 0 auto; \" valign=\"top\">" +
                     "<div class=\"content\"style=\"font-family:\'Helvetica Neue',Helvetica,Arial,sans - serif; box - sizing: border - box; font - size: 14px; max - width: 600px; display: block; margin: 0 auto; padding: 20px; \">" +
                     "<table class=\"main\"width=\"100 %\" cellpadding=\"0\"cellspacing=\"0\" itemprop=\"action\" itemtype=\"http://schema.org/ConfirmAction \"style=\"font-family:\'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-b;\">" +
                     "<tbody>" +
                     "<tr style=\"font-family:\'Helvetica Neue',Helvetica,Arial,sans - serif; box - sizing: border - box; font - size: 14px; margin: 0;\">" +
                     "<td class=\"content - wrap\" style=\"font-family:\'Helvetica Neue',Helvetica,Arial,sans - serif; box - sizing: border - box; font - size: 14px; vertical - align: top; margin: 0; padding: 30px; border: 3px solid #67a8e4;border-radius: 7px; background-color: #fff;\" valign=\"top\">" +
                     "<meta itemprop=\"name\" content=\"Confirm Email\" style=\"font-family:\'Helvetica Neue',Helvetica,Arial,sans - serif; box - sizing: border - box; font - size: 14px; margin: 0; \">" +
                     "<table width=\"100 % \"cellpadding=\"0\" cellspacing=\"0\" style=\"font-family:\'Helvetica Neue',Helvetica,Arial,sans - serif; box - sizing: border - box; font - size: 14px; margin: 0; \">" +
                     "<tbody>" +
                     "<tr style=\"font-family:\'Helvetica Neue',Helvetica,Arial,sans - serif; box - sizing: border - box; font - size: 14px; margin: 0; \">" +
                     "<td class=\"content - block\" style=\"font-family:\'Helvetica Neue',Helvetica,Arial,sans - serif; box - sizing: border - box; font - size: 14px; vertical - align: top; margin: 0; padding: 0 0 20px; \" valign=\"top\">" +
                     "Hi " + "<b>" + blockedName + "</b>" + " hope you doing well :)" +
                     "</td>" +
                     "</tr>" +
                     "<tr style=\"font-family:\'HelveticaNeue\',Helvetica,Arial,sans - serif; box - sizing:border - box; font-size:14px;margin: 0;\">" +
                     " <td class=\"content - block\" style=\"font-family:\'Helvetica Neue',Helvetica,Arial,sans - serif; box - sizing: border - box; font - size: 14px; vertical - align: top; margin: 0; padding: 0 0 20px;\" valign=\"top\">" +
                     "We want you to inform you that " + "<b>" + blockerName + "</b>" + " have been blocked you in our website ^^" +
                     "</td>" +
                     "</tr>" +
                     "<tr style=\"font-family:\'Helvetica Neue',Helvetica,Arial,sans - serif; box - sizing: border - box; font - size: 14px; margin: 0; \">" +
                     "<td class=\"content-block\" itemprop=\"handler\" itemscope=\"\" itemtype=\"http://schema.org/HttpActionHandler \" style=\"font-family:\'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; vertical-align: top; margin: 0; padding: 0 0 20px;\" valign=\"top\">" +
                     " <a href=\"https://www.youtube.com/watch?v=Khpzs-7WWeA \" class=\"btn-primary\" itemprop=\"url\" style=\"font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; color: #FFF; text-decoration: none; line-height: 2em; font-weight: bold; text-align: center; cursor: pointer; display: inline-block; border-radius: 5px; text-transform: capitalize; background-color: #f06292; margin: 0; border-color: #f06292; border-style: solid; border-width: 8px 16px;\">" +
                     "It's Okay" + "\n" + "No problem ? :)" + "</a>" + "</td>" + " </tr>" +
                    "<tr style=\"font-family:\'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;\" >" +
                    "<td class=\"content-block\" style=\"font-family:\'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; vertical-align: top; margin: 0; padding: 0 0 20px;\" valign=\"top\">" +
                      "<b>" + "Waed-Waedwebsite" + "</b>" +
                      " <p>" + "Support Team" + "</p>" +
                     "</td>" +
                      "</tr>" +
                      "<tr style =\"font-family:\'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;\" >" +
                      "<td class=\"content-block\" style=\"text-align: center;font-family:\'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; vertical-align: top; margin: 0; padding: 0;\" valign=\"top\">" +
                      "</td>" +
                     "</tr>" +
                     " </tbody >" +
                      "</table >" +
                       "</td>" +
                                "</tr >" +
                            "</tbody >" +
                        "</table >" +
                    "</div>" +
                "</td>" +
            "</tr>" +
        "</tbody >" +
   " </table>" +
  " </body>" +
"</html>";

            message.Body = builder.ToMessageBody();
            message.Subject = "Block Notifcation";
            message.From.Add(from);
            message.To.Add(to);
            using (var item = new MailKit.Net.Smtp.SmtpClient())
            {
                item.Connect("smtp.gmail.com", 587, false);
                item.Authenticate("wshareaa@gmail.com", "raaplatpmlacyfis");
                item.Send(message);
                item.Disconnect(true);
            }


            return true;
        }
        public bool RemoveBlock(FriendShipApi friend)
        {
            //Remove block that mean users become have not any relation 
            IEnumerable<FriendShipApi> friends = dbContext.dbConnection.Query<FriendShipApi>("FriendShipApi_package.getallFriendShipApi", commandType: CommandType.StoredProcedure);
            if (friends.Any(f => f.acceptId == friend.acceptId && f.requestId == friend.requestId && friend.Is_Blocked == 1))
            {

                var parameter = new DynamicParameters();

                parameter.Add("senderOfFriendShip", friend.requestId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                parameter.Add("reciverOfFriendShip", friend.acceptId, dbType: DbType.Int32, direction: ParameterDirection.Input);

                var result = dbContext.dbConnection.ExecuteAsync("FriendShipApi_package.deleteFriendShipApi", parameter, commandType: CommandType.StoredProcedure);
                if (result != null)
                    return true;
                else return false;

            }
            else return false;
     
        }





       





    }


}
