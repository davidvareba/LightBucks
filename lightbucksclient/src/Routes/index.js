import React from 'react';
import PropTypes from 'prop-types';
import { Route, Routes as Routing } from 'react-router-dom';
import About from '../Views/About';
import Coffee from '../Views/Coffee';
import Snack from '../Views/Snack';
import Tea from '../Views/Tea';
import Edit from '../Views/Edit';
import Favorite from '../Views/Favorite';
import Contact from '../Views/Contact';

export default function Routes({ userId }) {
  return (
    <Routing>
        <Route path="/about" element={ <About />} />
        <Route path="/coffees" element={ <Coffee  />} />
        <Route path="/teas" element={ <Tea  />} />
        <Route path="/snacks" element={ <Snack  />} />
        <Route path="/contact" element={ <Contact  />} />
        <Route
          exact
          path="/edit/:firebaseKey"
          component={() => <Edit userId={userId} />}
        />
        <Route
          exact
          path="/favorite"
          component={() => <Favorite userId={userId} />}
        />
    </Routing>
  );
}

Routes.propTypes = {
  userId: PropTypes.string,
};

Routes.defaultProps = { userId: {} };
