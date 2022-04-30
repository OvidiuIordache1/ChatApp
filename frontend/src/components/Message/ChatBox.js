import Message from "./Message";
import AuthContext from "../../store/auth-context";
import jwt_decode from "jwt-decode";
import { HubConnectionBuilder, LogLevel } from "@microsoft/signalr";
import { useState, useEffect, useRef, useContext } from "react";
import "../Messenger/Messenger.css";

const ChatBox = ({ currentChat, msg, setMsg }) => {
  const [messages, setMessages] = useState([]);
  const [newMessage, setNewMessage] = useState("");
  const [connection, setConnection] = useState();
  const authCtx = useContext(AuthContext);
  const scrollRef = useRef();

  var userId = jwt_decode(authCtx.token).nameid;

  const joinRoom = async (user, room) => {
    try {
      room = room.toString();
      const connection = new HubConnectionBuilder()
        .withUrl("https://localhost:5001/chat")
        .configureLogging(LogLevel.Information)
        .build();

      connection.on("ReceiveMessage", (msg) => {
        console.log("message revceived: ", msg);
        setMessages((messages) => [...messages, msg]);
      });

      await connection.start();
      await connection.invoke("JoinRoom", { user, room });
      setConnection(connection);
      setMsg(!msg);
    } catch (e) {
      console.log(e);
    }
  };

  const sendMessage = async (message) => {
    try {
      await connection.invoke("SendMessage", message);
    } catch (e) {
      console.log(e);
    }
  };

  useEffect(() => {
    if (currentChat != null) {
      joinRoom(userId, currentChat);
    }
  }, [currentChat]);

  useEffect(() => {
    const getMessages = async () => {
      if (currentChat != null) {
        try {
          await fetch(
            `https://localhost:5001/api/Message/get-messages-for-group/${currentChat}`
          ).then((res) => {
            if (res.ok) {
              res.json().then((data) => {
                setMessages(data);
              });
            }
          });
        } catch (err) {
          console.log(err);
        }
      }
    };
    const updateMsgDetails = async () => {
      if (currentChat != null) {
        var date = new Date();
        var myDotNetDate = date.toISOString();
        const messageDetail = {
          dateAndTime: myDotNetDate,
          dstId: userId,
          grId: currentChat,
        };
        try {
          await fetch(
            "https://localhost:5001/api/MessageDetail/update-message-detail",
            {
              method: "PUT",
              body: JSON.stringify(messageDetail),
              headers: {
                "Content-Type": "application/json",
              },
            }
          ).then((res) => {
            if (res.ok) {
              // ...
            }
          });
        } catch (err) {
          console.log(err);
        }
      }
    };
    getMessages();
    updateMsgDetails();
  }, [currentChat]);

  const handleSubmit = async (m) => {
    m.preventDefault();
    var date = new Date();
    var myDotNetDate = date.toISOString();
    const message = {
      senderId: userId,
      groupId: currentChat,
      text: newMessage,
    };
    try {
      await fetch("https://localhost:5001/api/Message/create-message", {
        method: "POST",
        body: JSON.stringify(message),
        headers: {
          "Content-Type": "application/json",
        },
      }).then((res) => {
        if (res.ok) {
          setNewMessage("");
          setMsg(!msg);
        }
      });
    } catch (err) {
      console.log(err);
    }
    try {
      await fetch(
        `https://localhost:5001/api/UserInfo/get-names/${userId}`
      ).then((res) => {
        if (res.ok) {
          res.json().then((data) => {
            const message = {
              userId: userId,
              groupId: currentChat,
              text: newMessage,
              dateAndTime: myDotNetDate,
              firstName: data[0],
              lastName: data[1],
            };
            sendMessage(message);
          });
        }
      });
    } catch (err) {
      console.log(err);
    }
  };

  useEffect(() => {
    scrollRef.current?.scrollIntoView({ behavior: "smooth" });
  }, [messages]);

  return (
    <div className="chatBoxWrapper">
      {currentChat ? (
        <>
          <div className="chatBoxTop">
            {messages.map((m) => (
              <div ref={scrollRef}>
                <Message message={m} own={m.userId.toString() === userId} />
              </div>
            ))}
          </div>
          <div className="chatBoxBottom">
            <textarea
              onChange={(m) => setNewMessage(m.target.value)}
              value={newMessage}
              className="chatMessageInput"
              placeholder="Write Something..."
            ></textarea>
            <button className="ChatSubmitButton" onClick={handleSubmit}>
              Send
            </button>
          </div>
        </>
      ) : (
        <span className="noConversationText">
          Open a conversation to start a chat.
        </span>
      )}
    </div>
  );
};

export default ChatBox;
