// hooks/useTelegramScript.js
import { useEffect } from "react";

export function useTelegramScript() {
  useEffect(() => {
    if (typeof window !== "undefined" && !window.Telegram) {
      const script = document.createElement("script");
      script.src = "https://telegram.org/js/telegram-web-app.js";
      script.async = true;
      document.head.appendChild(script);

      script.onload = () => console.log("✅ Telegram API загружен!");
    }
  }, []);
}

export function useTelegramUserUnsafe() {
  if (typeof window !== "undefined" && window.Telegram?.WebApp) {
    const telegram = window.Telegram.WebApp;

    const user = telegram.initDataUnsafe?.user;

    if (user) {
      console.log("Получены данные пользователя Telegram:", user);
      return user;
    }
  }

  return undefined;
}