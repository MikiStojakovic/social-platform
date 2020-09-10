import { observable } from 'mobx';
import { createContext } from 'react';

class ActivityStore {
  @observable title = 'Hello form mobx';
}

export default createContext(new ActivityStore());
