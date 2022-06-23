import React, { useState, useEffect } from 'react';
import { onAuthStateChanged } from 'firebase/auth';
import auth from '../Data/ApiKeys';
import SignIn from '../Views/SignIn';
import Navbar from '../Components/Navbar';
import Routes from '../Routes';

function Initialize() {
  const [user, setUser] = useState(null);

  useEffect(() => {
    onAuthStateChanged(auth, (authed) => {
      if (authed) {
        const userInfoObj = {
          fullName: authed.displayName,
          profileImage: authed.photoURL,
          uid: authed.uid,
          user: authed.email.split('@')[0],
        };
        setUser(userInfoObj);
      } else if (user || user === null) {
        setUser(false);
      }
    });
  }, []);

  return (
    <div className="App">
      {user ? (
        <>
          <Navbar />
          <Routes userId={user.uid} />
        </>
      ) : (
        <SignIn user={user} />
      )}
    </div>
  );
}

export default Initialize;
