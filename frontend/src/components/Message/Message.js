import "./Message.css";
import { format } from "timeago.js";

const Message = ({ message, own }) => {
  return (
    <div className="body">
      {!own && (
        <h5>
          {message.firstName} {message.lastName}
        </h5>
      )}
      <div className={own ? "message my_msg" : "message other_msg"}>
        <p>
          {message.text}
          <br />
          <span>{format(message.dateAndTime)}</span>
        </p>
      </div>
    </div>
  );
};

export default Message;
