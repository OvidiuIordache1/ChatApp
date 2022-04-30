import "./GroupInfo.css";

const GroupInfo = ({ user }) => {
  return (
    <div className="groupInfoUser">
      {/* <img
        className="groupInfoImg"
          src="https://media.istockphoto.com/photos/picturesque-morning-in-plitvice-national-park-colorful-spring-scene-picture-id1093110112?k=20&m=1093110112&s=612x612&w=0&h=3OhKOpvzOSJgwThQmGhshfOnZTvMExZX2R91jNNStBY="
          alt=""
        /> */}
      <span className="groupInfoName">
        {user.firstName} {user.lastName}
      </span>
    </div>
  );
};

export default GroupInfo;
