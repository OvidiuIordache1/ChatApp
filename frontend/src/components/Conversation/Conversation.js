import "./Conversation.css";
import { format } from "timeago.js";

const Conversation = ({ conversation }) => {
  return (
    <div className="conversation">
      <div className="block">
        {/* <img
          className="conversationImg"
          src="https://media.istockphoto.com/photos/picturesque-morning-in-plitvice-national-park-colorful-spring-scene-picture-id1093110112?k=20&m=1093110112&s=612x612&w=0&h=3OhKOpvzOSJgwThQmGhshfOnZTvMExZX2R91jNNStBY="
          alt=""
        /> */}
        <div className="details">
          <div className="listHead">
            <h4>{conversation.grName}</h4>
            <p className="time">{format(conversation.dateAndTime)}</p>
          </div>
          <h5>
            {conversation.lastMessageFirstName}{" "}
            {conversation.lastMessageLastName}:
          </h5>
          <div className="message_p">
            <p>{conversation.lastMessageText}</p>
            {/* <b>{conversation.nrUnreadMsg}</b> */}
          </div>
        </div>
      </div>
    </div>
  );
};

export default Conversation;
