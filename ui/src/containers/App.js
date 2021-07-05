import React from 'react';
import './App.css';
import MainRouter from './MainRouter';
import theme from '../theme';
import { ThemeProvider } from '@material-ui/core/styles';

function App() {
  return (
    <ThemeProvider theme={theme}>
      <div className='masterContainer'>
        <MainRouter />
      </div>
    </ThemeProvider>
  );
}

export default App;
