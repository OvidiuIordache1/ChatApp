import { useRef } from "react";
import { useHistory } from "react-router-dom";

import classes from "./AuthForm.module.css";

const RegisterForm = () => {
  const history = useHistory();

  const emailInputRef = useRef();
  const passwordInputRef = useRef();
  const firstNameRef = useRef();
  const lastNameRef = useRef();

  const submitHandler = (event) => {
    event.preventDefault();

    const enteredEmail = emailInputRef.current.value;
    const enteredPassword = passwordInputRef.current.value;
    const enteredFistName = firstNameRef.current.value;
    const enteredLastName = lastNameRef.current.value;

    fetch("https://localhost:5001/api/Auth/Register", {
      method: "POST",
      body: JSON.stringify({
        email: enteredEmail,
        password: enteredPassword,
        role: "user",
      }),
      headers: {
        "Content-Type": "application/json",
      },
    }).then((res) => {
      if (res.ok) {
        res.json().then((data) => {
          // console.log(data);
          fetch("https://localhost:5001/api/UserInfo/create-user-info", {
            method: "POST",
            body: JSON.stringify({
              id: data,
              firstName: enteredFistName,
              lastName: enteredLastName,
            }),
            headers: {
              "Content-Type": "application/json",
            },
          }).then((res) => {
            if (res.ok) {
              history.push("/login");
            }
          });
        });
      } else {
        res.json().then((data) => {
          console.log("Register Failed.");
          // console.log(data);
        });
      }
    });
  };

  return (
    <section className={classes.auth}>
      <h1>Register</h1>
      <form onSubmit={submitHandler}>
        <div className={classes.control}>
          <label htmlFor="email">Your Email</label>
          <input type="email" id="email" required ref={emailInputRef} />
        </div>
        <div className={classes.control}>
          <label htmlFor="password">Your Password</label>
          <input
            type="password"
            id="password"
            required
            ref={passwordInputRef}
          />
        </div>
        <div className={classes.control}>
          <label>First Name</label>
          <input type="text" id="firstName" required ref={firstNameRef} />
        </div>
        <div className={classes.control}>
          <label>Last Name</label>
          <input type="text" id="lastName" required ref={lastNameRef} />
        </div>
        <div className={classes.actions}>
          <button>Create Account</button>
        </div>
      </form>
      <h1>Password min length: 6 char.</h1>
      <h1>Must contain at least 1 digit, upperCase and lowerCase char.</h1>
    </section>
  );
};

export default RegisterForm;
