import React from 'react';
import ReactDOM from 'react-dom';
import { MemoryRouter } from 'react-router-dom';

import App from './App';


// global.fetch = jest.fn(() =>
//   Promise.resolve({
//     json: () => Promise.resolve({ 
//       employee:{
//         firstname: 'jeff',
//         birthdate: '2022-01-01',
//         tin:'123',
//         typeId: 1

      
//     } } ),
//   })
// );

it('renders without crashing', async () => {
  const div = document.createElement('div');
  ReactDOM.render(
    <MemoryRouter>
      <App />
    </MemoryRouter>, div);
  await new Promise(resolve => setTimeout(resolve, 1000));
});



