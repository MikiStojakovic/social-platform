import React, { useContext } from 'react'
import { Card, Header, Tab, Image } from 'semantic-ui-react'
import { RootStoreContext } from '../../app/stores/rootStore'

export const ProfilePhotos = () => {
 const rootStore = useContext(RootStoreContext);
 const {profile} = rootStore.profileStore;

 return (
  <Tab.Pane>
   <Header icon='image' content='Photos'/>
   <Card.Group itemPerRow={5}>
    {profile && profile.photos.map((photo) => (
     <Card key={photo.id}>
      <Image src={photo.url}/>
     </Card>     
    ))}
   </Card.Group>
   </Tab.Pane>
 )
}
