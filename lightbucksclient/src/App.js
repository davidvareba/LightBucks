// import React, { useState, useEffect } from 'react';
// import firebase from 'firebase/app';
// import 'firebase/auth';
// import SignIn from '../views/SignIn';
// import Navbar from '../Components/Navbar';
// import Routes from '../Routes';

// function App() {
//   const [user, setUser] = useState(null);

//   useEffect(() => {
//     firebase.auth().onAuthStateChanged((authed) => {
//       if (authed) {
//         const userInfoObj = {
//           fullName: authed.displayName,
//           profileImage: authed.photoURL,
//           uid: authed.uid,
//           user: authed.email.split('@')[0],
//         };
//         setUser(userInfoObj);
//       } else if (user || user === null) {
//         setUser(false);
//       }
//     });
//   }, []);

//   return (
//     <div className="App">
//       {user ? (
//         <> 
//           <Navbar />
//           <Routes userId={user.uid} />
//         </>
//       ) : (
//         <SignIn user={user} />
//       )}
//     </div>
//   );
// }

// export default App;
