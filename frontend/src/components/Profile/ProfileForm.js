import classes from "./ProfileForm.module.css";
import { useState, useContext } from "react";
import AuthContext from "../../store/auth-context";
import jwt_decode from "jwt-decode";

const ProfileForm = () => {
  const authCtx = useContext(AuthContext);
  const [firstNameInput, setFirstNameInput] = useState("");
  const [lastNameInput, setLastNameInput] = useState("");
  var userId = jwt_decode(authCtx.token).nameid;

  const handleNewFistName = async (p) => {
    p.preventDefault();
    const firstName = firstNameInput;
    const lastName = "";
    try {
      await fetch(`https://localhost:5001/api/UserInfo/update-user`, {
        method: "PUT",
        body: JSON.stringify({
          Id: userId,
          FirstName: firstName,
          LastName: lastName,
        }),
        headers: {
          "Content-Type": "application/json",
        },
      }).then((res) => {
        if (res.ok) {
          setFirstNameInput("");
          setLastNameInput("");
        }
      });
    } catch (err) {
      console.log(err);
    }
  };

  const handleNewLastName = async (p) => {
    p.preventDefault();
    const firstName = "";
    const lastName = lastNameInput;
    try {
      await fetch(`https://localhost:5001/api/UserInfo/update-user`, {
        method: "PUT",
        body: JSON.stringify({
          Id: userId,
          FirstName: firstName,
          LastName: lastName,
        }),
        headers: {
          "Content-Type": "application/json",
        },
      }).then((res) => {
        if (res.ok) {
          setFirstNameInput("");
          setLastNameInput("");
        }
      });
    } catch (err) {
      console.log(err);
    }
  };

  return (
    <form className={classes.form}>
      <div className={classes.control}>
        <label htmlFor="new-first-name">New First Name</label>
        <input
          type="text"
          id="new-first-name"
          onChange={(m) => setFirstNameInput(m.target.value)}
          value={firstNameInput}
        />
      </div>
      <div className={classes.action}>
        <button onClick={handleNewFistName}>Change First Name</button>
      </div>

      <br></br>

      <div className={classes.control}>
        <label htmlFor="new-last-name">New Last Name</label>
        <input
          type="text"
          id="new-last-name"
          onChange={(m) => setLastNameInput(m.target.value)}
          value={lastNameInput}
        />
      </div>
      <div className={classes.action}>
        <button onClick={handleNewLastName}>Change Last Name</button>
      </div>
    </form>
  );
};

export default ProfileForm;
