import { useContext } from "react";

import { Switch, Route, Redirect } from "react-router-dom";

import Layout from "./components/Layout/Layout";
import UserProfile from "./components/Profile/UserProfile";
import RegisterPage from "./pages/RegisterPage";
import LoginPage from "./pages/LoginPage";
import HomePage from "./pages/HomePage";
import AuthContext from "./store/auth-context";

function App() {
  const authCtx = useContext(AuthContext);

  const isLoggedIn = authCtx.isLoggedIn;

  return (
    <Layout>
      <Switch>
        <Route path="/" exact>
          {!isLoggedIn && <Redirect to="/login"></Redirect>}
          {isLoggedIn && <HomePage />}
        </Route>
        {!isLoggedIn && (
          <Route path="/register">
            <RegisterPage />
          </Route>
        )}
        {!isLoggedIn && (
          <Route path="/login">
            <LoginPage />
          </Route>
        )}
        {isLoggedIn && (
          <Route path="/profile">
            <UserProfile />
          </Route>
        )}
        <Route path="*">
          <Redirect to="/" />
        </Route>
      </Switch>
    </Layout>
  );
}

export default App;
