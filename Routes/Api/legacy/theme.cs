namespace massthrakz.Routes.Api.legacy;

public static class Theme
{
    public static IEndpointRouteBuilder LegacyGradeColorHandler(this WebApplication app)
    {
        /*
         {
          "public_id": "unique_color_id_123",
          "is_public": "true",
          "nickname": "Vibrant Grades",
          "five_color": "4282339839",
          "four_color": "4283416447",
          "three_color": "4294956551",
          "two_color": "4294925312",
          "one_color": "4294198070"
         }
         */
        app.MapPost("/api/legacy/theme/gradeColor", () =>
        {
            return Results.Created();
        });
        return app;
    }

    public static IEndpointRouteBuilder LegacyThemeShareHandler(this WebApplication app)
    {
        List<string> supportedFonts = ["Montserrat", "Merienda", "M PLUS Code Latin", "Figtree", "Fira Code", "Vollkorn"];
        /*
           {
            "public_id": "unique_theme_id_456",
            "is_public": "true",
            "nickname": "Cool Dark Theme",
            "background_color": "4278190080",
            "panels_color": "4279834991",
            "accent_color": "4287090304",
            "icon_color": "4294967295",
            "shadow_effect": "true",
            "grade_colors_id": "unique_color_id_123",
            "display_name": "My Awesome Theme",
            "theme_mode": "dark",
            "font_family": "Montserrat"
           }
         */
        app.MapPost("/api/legacy/theme/share", () =>
        {
            
        });
        return app;
    }
}