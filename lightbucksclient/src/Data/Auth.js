import { signInWithPopup, GoogleAuthProvider, getAuth } from 'firebase/auth';
import auth from './ApiKeys';

// These helpers allow you to login and out of FB auth with Google. These are Firebase methods and is broilerplate code.

const signInUser = async () => {
    const provider = await new GoogleAuthProvider();
    signInWithPopup(auth, provider);
};
const signOutUser = () => {
    new Promise((resolve, reject) => {
        getAuth().signOut().then(resolve).catch(reject);
    });
};
export { signInUser, signOutUser };
