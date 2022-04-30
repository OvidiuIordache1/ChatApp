import Conversation from "../Conversation/Conversation";
import { useState, useContext, useEffect } from "react";
import AuthContext from "../../store/auth-context";
import "./Messenger.css";
import jwt_decode from "jwt-decode";
import GroupInfoBox from "../GroupInfo/GroupInfoBox";
import ChatBox from "../Message/ChatBox";

const Messenger = () => {
  const authCtx = useContext(AuthContext);
  const [conversations, setConversations] = useState([]);
  const [currentChat, setCurrentChat] = useState(null);
  const [msg, setMsg] = useState(false); // use to update Conversation
  const [btnCreateClick, setBtnCreateClick] = useState(false);
  const [btnJoinClick, setBtnJoinClick] = useState(false);
  const [btnInput, setBtnInput] = useState("");

  var userId = jwt_decode(authCtx.token).nameid;

  useEffect(() => {
    const getConversations = async () => {
      try {
        await fetch(
          `https://localhost:5001/api/Conversation/get-conversations/${userId}`
        ).then((res) => {
          if (res.ok) {
            res.json().then((data) => {
              setConversations(data);
            });
          }
        });
      } catch (err) {
        console.log(err);
      }
    };
    getConversations();
  }, [userId, msg]);

  const handleCreateClick = async (gr) => {
    setBtnCreateClick(!btnCreateClick);
  };

  const handleJoinClick = async (gr) => {
    setBtnJoinClick(!btnJoinClick);
  };

  const handleGroupCreate = async (gr) => {
    gr.preventDefault();
    const grName = btnInput;
    console.log(btnInput);
    try {
      await fetch(
        `https://localhost:5001/api/Group/create-group-with-user/${grName}/${userId}`,
        {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
        }
      ).then((res) => {
        if (res.ok) {
          setBtnInput("");
          setBtnCreateClick(!btnCreateClick);
          setMsg(!msg);
        }
      });
    } catch (err) {
      console.log(err);
    }
  };

  const handleGroupJoin = async (gr) => {
    gr.preventDefault();
    const grCode = btnInput;
    try {
      await fetch(
        `https://localhost:5001/api/Group/add-user-with-code/${grCode}/${userId}`,
        {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
        }
      ).then((res) => {
        if (res.ok) {
          setBtnInput("");
          setBtnCreateClick(!btnCreateClick);
          setMsg(!msg);
        }
      });
    } catch (err) {
      console.log(err);
    }
  };

  return (
    <div className="messenger">
      <div className="chatGroup">
        <div className="chatGroupWrapper">
          <input placeholder="Search group" className="chatGroupInput" />
          <button className="groupButton" onClick={handleCreateClick}>
            Create Group
          </button>
          <button className="groupButton" onClick={handleJoinClick}>
            Join Group
          </button>
          {btnCreateClick && (
            <>
              <input
                onChange={(m) => setBtnInput(m.target.value)}
                value={btnInput}
                className="btnInput"
                placeholder="Group name"
              ></input>
              <button className="enterButton" onClick={handleGroupCreate}>
                Enter
              </button>
            </>
          )}
          {btnJoinClick && (
            <>
              <input
                onChange={(m) => setBtnInput(m.target.value)}
                value={btnInput}
                className="btnInput"
                placeholder="Join Code"
              ></input>
              <button className="enterButton" onClick={handleGroupJoin}>
                Enter
              </button>
            </>
          )}
          {conversations.map((c) => (
            <div onClick={() => setCurrentChat(c.grId)}>
              <Conversation key={c.grId} conversation={c} />
            </div>
          ))}
        </div>
      </div>
      <div className="chatBox">
        <ChatBox currentChat={currentChat} msg={msg} setMsg={setMsg}></ChatBox>
      </div>
      <div className="groupInfoBox">
        <GroupInfoBox currentChat={currentChat} />
      </div>
    </div>
  );
};

export default Messenger;
