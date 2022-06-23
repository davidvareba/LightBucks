import React from 'react';
import PropTypes from 'prop-types';
import { Spinner } from 'reactstrap';
import { signInUser } from '../Data/Auth';

export default function SignIn({ user }) {
  return (
    <>
      {user === null ? (
        <div className="text-center">
          <Spinner
            style={{ width: '10rem', height: '10rem' }}
            color="warning"
          />
        </div>
      ) : (
        <div className="sign-in mt-5" align="center">
          <p>
            <button
              type="button"
              className="btn btn-success"
              onClick={signInUser}
            >
              Sign In
            </button>
          </p>
          <img className="vadana" alt="profileImage" src="https://images-eu.ssl-images-amazon.com/images/I/41CXV3pZ33L._SR600%2C315_PIWhiteStrip%2CBottomLeft%2C0%2C35_PIStarRatingFIVE%2CBottomLeft%2C360%2C-6_SR600%2C315_SCLZZZZZZZ_FMpng_BG255%2C255%2C255.jpg" />
        </div>
      )}
    </>
  );
}

SignIn.propTypes = {
  user: PropTypes.node,
};

SignIn.defaultProps = {
  user: null,
};
