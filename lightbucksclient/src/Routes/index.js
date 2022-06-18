import React from 'react';
import PropTypes from 'prop-types';
import { Route, Switch } from 'react-router-dom';
import About from '../views/About';
import Coffee from '../views/Coffee';
import Snack from '../views/Snack';
import Tea from '../views/Tea';
import Detail from '../views/Detail';
import Edit from '../views/Edit';
import Favorite from '../views/Favorite';
import Contact from '../components/Contact';

export default function Routes({ userId }) {
  return (
    <div>
      <Switch>
        console.warn({userId});
        <Route exact path="/about" component={() => <About userId={userId} />} />
        <Route exact path="/coffees" component={() => <Coffee userId={userId} />} />
        <Route exact path="/teas" component={() => <Tea userId={userId} />} />
        <Route exact path="/snacks" component={() => <Snack userId={userId} />} />
        <Route exact path="/contact" component={() => <Contact userId={userId} />} />
        <Route exact path="/detail/:firebaseKey" component={Detail} />
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
      </Switch>
    </div>
  );
}

Routes.propTypes = {
  userId: PropTypes.string,
};

Routes.defaultProps = { userId: {} };
