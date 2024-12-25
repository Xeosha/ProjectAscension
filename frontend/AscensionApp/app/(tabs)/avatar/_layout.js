import { Drawer } from "expo-router/drawer";
import { MaterialCommunityIcons } from '@expo/vector-icons';
import { View, Pressable, StyleSheet } from 'react-native';

export default function AvatarLayout() {

  const HeaderRight = () => (
    <View style={styles.headerButtons}>
      <Pressable 
        style={styles.headerButton}
        onPress={() => console.log('Customize pressed')}
      >
        <MaterialCommunityIcons name="pencil" size={24} color="#fff" />
      </Pressable>
      
      <Pressable 
        style={styles.headerButton}
        onPress={() => console.log('Notifications pressed')}
      >
        <MaterialCommunityIcons name="bell" size={24} color="#fff" />
      </Pressable>
    </View>
  );
  
  return (
    <Drawer
      screenOptions={{
        drawerStyle: {
          backgroundColor: "#f8f9fa",
          width: 240,
        },
        headerStyle: {
          backgroundColor: "#4a90e2",
        },
        headerTintColor: "#fff",
        headerRight: HeaderRight,
      }}
    >
      <Drawer.Screen 
        name="index" 
        options={{ 
          title: "Герои",
          drawerIcon: ({ color, size }) => (
            <MaterialCommunityIcons name="home" size={size} color={color} />
          ),
        }} 
      />
      <Drawer.Screen 
        name="health" 
        options={{ 
          title: "Здоровье",
          drawerIcon: ({ color, size }) => (
            <MaterialCommunityIcons name="heart" size={size} color={color} />
          ),
        }} 
      />
      <Drawer.Screen 
        name="achievements" 
        options={{ 
          title: "Достижения",
          drawerIcon: ({ color, size }) => (
            <MaterialCommunityIcons name="trophy" size={size} color={color} />
          ),
        }} 
      />
      <Drawer.Screen 
        name="settings" 
        options={{ 
          title: "Настройки",
          drawerIcon: ({ color, size }) => (
            <MaterialCommunityIcons name="cog" size={size} color={color} />
          ),
        }} 
      />
      <Drawer.Screen 
        name="support" 
        options={{ 
          title: "Поддержка",
          drawerIcon: ({ color, size }) => (
            <MaterialCommunityIcons name="help-circle" size={size} color={color} />
          ),
        }} 
      />
      <Drawer.Screen 
        name="language" 
        options={{ 
          title: "Настройки языка",
          drawerIcon: ({ color, size }) => (
            <MaterialCommunityIcons name="translate" size={size} color={color} />
          ),
        }} 
      />
      <Drawer.Screen 
        name="logout" 
        options={{ 
          title: "Выйти из аккаунта",
          drawerIcon: ({ color, size }) => (
            <MaterialCommunityIcons name="logout" size={size} color={color} />
          ),
        }}
      />
    </Drawer>
  );
}

const styles = StyleSheet.create({
  headerButtons: {
    flexDirection: 'row',
    marginRight: 10,
  },
  headerButton: {
    marginHorizontal: 8,
    padding: 4,
  },
});