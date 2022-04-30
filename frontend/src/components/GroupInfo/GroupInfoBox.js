import { useState, useEffect } from "react";
import GroupInfo from "./GroupInfo";
import "./GroupInfo.css";

const GroupInfoBox = ({ currentChat }) => {
  const [users, setUsers] = useState([]);
  const [groupName, setGroupName] = useState("");
  const [groupCode, setGroupCode] = useState("");

  useEffect(() => {
    const getUsers = async () => {
      if (currentChat != null) {
        try {
          await fetch(
            `https://localhost:5001/api/Group/get-users-and-names-for-group/${currentChat}`
          ).then((res) => {
            if (res.ok) {
              res.json().then((data) => {
                //   console.log(data);
                setUsers(data);
              });
            }
          });
        } catch (err) {
          console.log(err);
        }
      }
    };
    const getInfo = async () => {
      if (currentChat != null) {
        try {
          await fetch(
            `https://localhost:5001/api/Group/get-group-info/${currentChat}`
          ).then((res) => {
            if (res.ok) {
              res.json().then((data) => {
                setGroupName(data.name);
                setGroupCode(data.inviteCode);
              });
            }
          });
        } catch (err) {
          console.log(err);
        }
      }
    };
    getUsers();
    getInfo();
  }, [currentChat]);

  return (
    <div className="groupInfo">
      <p>User List:</p>
      <div className="groupInfoWrapper">
        {users.map((user) => (
          <GroupInfo key = {user.userId} user={user} />
        ))}
      </div>
      <p>
        Group Name: <span>{groupName}</span>
      </p>
      <p>
        Group Invite Code: <span>{groupCode}</span>
      </p>
    </div>
  );
};

export default GroupInfoBox;
